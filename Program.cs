using System.Collections.Generic;
using System.Linq;

namespace MergeDateLists
{
	class Program
	{
		static void Main(string[] args)
		{
			RunAllTests();
		}

		/// <summary>
		/// Sets up Sample Data and Tests the results
		/// </summary>
		private static void RunAllTests()
		{
			#region Test0

			var parents = CreateSamples.CreateSampleParents0();
			var children = CreateSamples.CreateSampleChildren0();

			var mergedList = MergeItems(parents, children);
			
			CreateSamples.CompareResults0(mergedList.ToList());

			#endregion

			#region Test1

			parents = CreateSamples.CreateSampleParents1();
			children = CreateSamples.CreateSampleChildren1();

			mergedList = MergeItems(parents, children);
			
			CreateSamples.CompareResults1(mergedList.ToList());

			#endregion
			
			#region Test2

			parents = CreateSamples.CreateSampleParents2();
			children = CreateSamples.CreateSampleChildren2();

			mergedList = MergeItems(parents, children);
			
			CreateSamples.CompareResults2(mergedList.ToList());

			#endregion

			#region Test3

			parents = CreateSamples.CreateSampleParents3();
			children = CreateSamples.CreateSampleChildren3();

			mergedList = MergeItems(parents, children);
			
			CreateSamples.CompareResults3(mergedList.ToList());

			#endregion
			
			#region Test4

			parents = CreateSamples.CreateSampleParents4();
			children = CreateSamples.CreateSampleChildren4();

			mergedList = MergeItems(parents, children);
			
			CreateSamples.CompareResults4(mergedList.ToList());

			#endregion
			
			#region Test5

			parents = CreateSamples.CreateSampleParents5();
			children = CreateSamples.CreateSampleChildren5();

			mergedList = MergeItems(parents, children);
		}

		private static IEnumerable<Item> MergeItems(IEnumerable<Item> parents, IEnumerable<Item> children)
		{
			var parentsList = parents.ToList();
			// Children contain same BillingInformation like parents if they don't have any own ones.
			// Return parentSections if it's the case.
			if (parentsList.Any(p => children.Any(c => c.Id == p.Id)))
			{
				return parentsList;
			}
			
			var mergedList = UniteLists(parentsList, children.ToList());
			return DoMagic(mergedList.ToList(), parentsList);
		}
		
		private static List<Item> DoMagic(List<Item> mergedList, List<Item> parentsList)
		{
			for (int i = 0; i < mergedList.Count; i++)
			{
				// Determine if its a child
				var isChild = parentsList.All(x => x.Id != mergedList[i].Id);
				
				// Handle Element if it has no End Value
				if (!mergedList[i].End.HasValue)
				{
					HandleElemtWithoutEnd(mergedList, i, isChild);	
				}

				// Skip children
				if (isChild)
				{
					continue;	
				}

				// Check if Begin value needs to be reassigned -> if so check if the element is still valid else delete it
				if (!ReassignBegin(mergedList, i))
				{
					mergedList.RemoveAt(i--);
					continue;
				}

				if (!ReassignEnd(mergedList, i))
				{
					mergedList.RemoveAt(i--);
					continue;
				}
			}

			return mergedList;
		}
	
		/// <summary>
		/// Checks if the End needs to be reassigned and will do if so.
		/// </summary>
		/// <param name="mergedList"></param>
		/// <param name="i"></param>
		/// <returns>Whether the changed Item is still valid</returns>
		private static bool ReassignEnd(List<Item> mergedList, int i)
		{
			// check if End is valid
			if (i < mergedList.Count - 1)
			{
				if (mergedList[i].End.Value >= mergedList[i + 1].Begin)
				{
					if (mergedList[i].End.Value > mergedList[i + 1].End)
					{
						var newParent = new Item
						{
							Begin = mergedList[i + 1].End.Value.AddDays(1),
							End = mergedList[i].End,
							Id = mergedList[i].Id
						};
						if (CheckIfElementIsValid(newParent))
						{
							mergedList.Insert(i + 2, newParent);
						}
					}
					mergedList[i].End = mergedList[i + 1].Begin.AddDays(-1);
					return CheckIfElementIsValid(mergedList[i]);
				}
			}

			return true;
		}

		/// <summary>
		/// Checks if the Begin needs to be reassigned and will do if so.
		/// </summary>
		/// <param name="mergedList"></param>
		/// <param name="i"></param>
		/// <returns>Whether the changed Item is still valid</returns>
		private static bool ReassignBegin(List<Item> mergedList, int i)
		{
			if (i > 0)
			{
				if (mergedList[i].Begin <= mergedList[i - 1].End!.Value)
				{
					mergedList[i].Begin = mergedList[i - 1].End!.Value.AddDays(1);
					return CheckIfElementIsValid(mergedList[i]);
				}
			}

			return true;
		}

		/// <summary>
		/// Checks if the Begin of the given Item is below or equals the End (valid) or not.
		/// </summary>
		/// <param name="item"></param>
		/// <returns>True when Element is valid</returns>
		private static bool CheckIfElementIsValid(Item item)
		{
			if (item.Begin <= item.End)
			{
				return true;
			}

			return false;
		}

		private static void HandleElemtWithoutEnd(List<Item> mergedList, int i, bool isChild)
		{
			if (i == mergedList.Count - 1)
			{
				return;
			}
			// If it is a child all Elements after it can be removed
			if (isChild)
			{
				mergedList.RemoveRange(i + 1, mergedList.Count - (i + 1));
				return;
			}
			// If the last element has no End value -> add End to parent
			if (!mergedList[^1].End.HasValue)
			{
				mergedList[i].End = mergedList[^1].Begin.AddDays(-1);
				return;
			}

			mergedList.Add(new Item
			{
				Begin = mergedList[^1].End.Value.AddDays(1),
				Id = mergedList[i].Id
			});
			mergedList[i].End = mergedList[^1].Begin.AddDays(-1);
		}

		private static IEnumerable<Item> UniteLists(List<Item> parentsList, List<Item> childrenList)
		{
			var pList = new List<Item>();
			foreach (var p in parentsList)
			{
				pList.Add(new Item
				{
					Begin = p.Begin,
					End = p.End,
					Id = p.Id
				});
			}
			var mergedList = childrenList.Union(pList);
			// Processes the list for indexing through it easier (Sorts by date and child before parent)
			return mergedList.OrderBy(x => x.Begin).ThenBy(x => pList.IndexOf(x));
		}
	}
}
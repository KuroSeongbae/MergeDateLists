using System;
using System.Collections.Generic;

namespace MergeDateLists
{
	public class CreateSamples
	{

		#region Samples0

		public static IEnumerable<Item> CreateSampleParents0()
				{
					return new List<Item>
					{
						new Item
						{
							Begin = new DateTime(2021, 08, 01),
							End = new DateTime(2021, 08, 04),
							Id = 1
						},
						new Item
						{
							Begin = new DateTime(2021, 08, 17),
							End = new DateTime(2021, 08, 22),
							Id = 2
						},
						new Item
						{
							Begin = new DateTime(2021, 08, 25),
							End = new DateTime(2021, 08, 29),
							Id = 3
						},
					};
				}
				
		public static IEnumerable<Item> CreateSampleChilds0()
				{
					return new List<Item>
					{
						new Item
						{
							Begin = new DateTime(2021, 08, 06),
							End = new DateTime(2021, 08, 09),
							Id = 4
						},
						new Item
						{
							Begin = new DateTime(2021, 08, 12),
							End = new DateTime(2021, 08, 15),
							Id = 5
						},
					};
				}

		public static void CompareResults0(List<Item> result)
				{
					var expected = new List<Item>
					{
						new Item
						{
							Begin = new DateTime(2021, 08, 01),
							End = new DateTime(2021, 08, 04),
							Id = 1
						},
						new Item
						{
							Begin = new DateTime(2021, 08, 06),
							End = new DateTime(2021, 08, 09),
							Id = 4
						},
						new Item
						{
							Begin = new DateTime(2021, 08, 12),
							End = new DateTime(2021, 08, 15),
							Id = 5
						},
						new Item
						{
							Begin = new DateTime(2021, 08, 17),
							End = new DateTime(2021, 08, 22),
							Id = 2
						},
						new Item
						{
							Begin = new DateTime(2021, 08, 25),
							End = new DateTime(2021, 08, 29),
							Id = 3
						},
					};

					CompareLists(expected, result);
				}
				
		#endregion

		#region Samples1

		public static IEnumerable<Item> CreateSampleParents1()
		{
			return new List<Item>
			{
				new Item
				{
					Begin = new DateTime(2021, 08, 01),
					End = new DateTime(2021, 08, 07),
					Id = 1
				},
				new Item
				{
					Begin = new DateTime(2021, 08, 12),
					End = new DateTime(2021, 08, 15),
					Id = 2
				},
				new Item
				{
					Begin = new DateTime(2021, 08, 18),
					End = new DateTime(2021, 08, 26),
					Id = 3
				},

				#region ParentSpansOverChilds

				new Item
				{
					Begin = new DateTime(2021, 09, 03),
					End = new DateTime(2021, 09, 26),
					Id = 4
				},

				#endregion
				
				#region ChildSpansOverParents

				new Item
				{
					Begin = new DateTime(2021, 10, 05),
					End = new DateTime(2021, 10, 07),
					Id = 5
				},
				new Item
				{
					Begin = new DateTime(2021, 10, 09),
					End = new DateTime(2021, 10, 15),
					Id = 6
				},
				new Item
				{
					Begin = new DateTime(2021, 10, 18),
					End = new DateTime(2021, 10, 22),
					Id = 7
				},

				#endregion
				new Item
				{
					Begin = new DateTime(2021, 11, 28),
					Id = 8
				},
			};
		}
		
		public static IEnumerable<Item> CreateSampleChilds1()
		{
			return new List<Item>
			{
				new Item
				{
					Begin = new DateTime(2021, 08, 01),
					End = new DateTime(2021, 08, 09),
					Id = 9
				},
				new Item
				{
					Begin = new DateTime(2021, 08, 10),
					End = new DateTime(2021, 08, 16),
					Id = 10
				},
				new Item
				{
					Begin = new DateTime(2021, 08, 20),
					End = new DateTime(2021, 08, 24),
					Id = 11
				},

				#region ParentSpansOverChilds

				new Item
				{
					Begin = new DateTime(2021, 09, 05),
					End = new DateTime(2021, 09, 07),
					Id = 12
				},
				new Item
				{
					Begin = new DateTime(2021, 09, 09),
					End = new DateTime(2021, 09, 15),
					Id = 13
				},
				new Item
				{
					Begin = new DateTime(2021, 09, 18),
					End = new DateTime(2021, 09, 22),
					Id = 14
				},

				#endregion

				#region ChildSpansOverParents

				new Item
				{
					Begin = new DateTime(2021, 10, 03),
					End = new DateTime(2021, 10, 26),
					Id = 15
				},

				#endregion
				new Item
				{
					Begin = new DateTime(2021, 11, 30),
					Id = 16
				},
			};
		}

		public static void CompareResults1(List<Item> result)
		{
			var expected = new List<Item>
				{
					new Item
					{
						Begin = new DateTime(2021, 08, 01),
						End = new DateTime(2021, 08, 09),
						Id = 9
					},
					new Item
					{
						Begin = new DateTime(2021, 08, 10),
						End = new DateTime(2021, 08, 16),
						Id = 10
					},
					new Item
					{
						Begin = new DateTime(2021, 08, 18),
						End = new DateTime(2021, 08, 19),
						Id = 3
					},
					new Item
					{
						Begin = new DateTime(2021, 08, 20),
						End = new DateTime(2021, 08, 24),
						Id = 11
					},
					new Item
					{
						Begin = new DateTime(2021, 08, 25),
						End = new DateTime(2021, 08, 26),
						Id = 3
					},
					
					#region ParentSpansOverChilds
					new Item
					{
						Begin = new DateTime(2021, 09, 03),
						End = new DateTime(2021, 09, 04),
						Id = 4
					},
					new Item
					{
						Begin = new DateTime(2021, 09, 05),
						End = new DateTime(2021, 09, 07),
						Id = 12
					},
					new Item
					{
						Begin = new DateTime(2021, 09, 08),
						End = new DateTime(2021, 09, 08),
						Id = 4
					},
					new Item
					{
						Begin = new DateTime(2021, 09, 09),
						End = new DateTime(2021, 09, 15),
						Id = 13
					},
					new Item
					{
						Begin = new DateTime(2021, 09, 16),
						End = new DateTime(2021, 09, 17),
						Id = 4
					},
					new Item
					{
						Begin = new DateTime(2021, 09, 18),
						End = new DateTime(2021, 09, 22),
						Id = 14
					},
					new Item
					{
						Begin = new DateTime(2021, 09, 23),
						End = new DateTime(2021, 09, 26),
						Id = 4
					},

					#endregion

					#region ChildSpansOverParents

					new Item
					{
						Begin = new DateTime(2021, 10, 03),
						End = new DateTime(2021, 10, 26),
						Id = 15
					},

					#endregion
					new Item
					{
						Begin = new DateTime(2021, 11, 28),
						End = new DateTime(2021, 11, 29),
						Id = 8
					},
					new Item
					{
						Begin = new DateTime(2021, 11, 30),
						Id = 16
					},
				};

			CompareLists(expected, result);
		}

		#endregion

		#region Samples2

		public static IEnumerable<Item> CreateSampleParents2()
		{
			return new List<Item>
			{
				new Item
				{
					Begin = new DateTime(2021, 08, 01),
					Id = 1
				},
			};
		}
				
		public static IEnumerable<Item> CreateSampleChilds2()
		{
			return new List<Item>
			{
				new Item
				{
					Begin = new DateTime(2021, 08, 06),
					End = new DateTime(2021, 08, 09),
					Id = 2
				},
				new Item
				{
					Begin = new DateTime(2021, 08, 12),
					End = new DateTime(2021, 08, 15),
					Id = 3
				},
				new Item
				{
					Begin = new DateTime(2021, 08, 20),
					End = new DateTime(2021, 08, 24),
					Id = 4
				},
			};
		}

		public static void CompareResults2(List<Item> result)
		{
			var expected = new List<Item>
			{
				new Item
				{
					Begin = new DateTime(2021, 08, 01),
					End = new DateTime(2021, 08, 05),
					Id = 1
				},
				new Item
				{
					Begin = new DateTime(2021, 08, 06),
					End = new DateTime(2021, 08, 09),
					Id = 2
				},
				new Item
				{
					Begin = new DateTime(2021, 08, 10),
					End = new DateTime(2021, 08, 11),
					Id = 1
				},
				new Item
				{
					Begin = new DateTime(2021, 08, 12),
					End = new DateTime(2021, 08, 15),
					Id = 3
				},
				new Item
				{
					Begin = new DateTime(2021, 08, 16),
					End = new DateTime(2021, 08, 19),
					Id = 1
				},
				new Item
				{
					Begin = new DateTime(2021, 08, 20),
					End = new DateTime(2021, 08, 24),
					Id = 4
				},
				new Item
				{
					Begin = new DateTime(2021, 08, 25),
					Id = 1
				},
			};

			CompareLists(expected, result);
		}

		#endregion
		
		#region Samples3

		public static IEnumerable<Item> CreateSampleParents3()
		{
			return new List<Item>
			{
				new Item
				{
					Begin = new DateTime(2021, 08, 06),
					End = new DateTime(2021, 08, 09),
					Id = 1
				},
				new Item
				{
					Begin = new DateTime(2021, 08, 12),
					End = new DateTime(2021, 08, 15),
					Id = 2
				},
				new Item
				{
					Begin = new DateTime(2021, 08, 20),
					End = new DateTime(2021, 08, 24),
					Id = 3
				},
			};
		}
				
		public static IEnumerable<Item> CreateSampleChilds3()
		{
			return new List<Item>
			{
				new Item
				{
					Begin = new DateTime(2021, 08, 01),
					Id = 4
				},
			};
		}

		public static void CompareResults3(List<Item> result)
		{
			var expected = new List<Item>
			{
				new Item
				{
					Begin = new DateTime(2021, 08, 01),
					Id = 4
				},
			};

			CompareLists(expected, result);
		}

		#endregion
		
		#region Samples4

		public static IEnumerable<Item> CreateSampleParents4()
		{
			return new List<Item>
			{
				new Item
				{
					Begin = new DateTime(2021, 08, 06),
					End = new DateTime(2021, 08, 09),
					Id = 1
				},
				new Item
				{
					Begin = new DateTime(2021, 08, 19),
					End = new DateTime(2021, 08, 25),
					Id = 2
				},
			};
		}
				
		public static IEnumerable<Item> CreateSampleChilds4()
		{
			return new List<Item>
			{
				new Item
				{
					Begin = new DateTime(2021, 08, 01),
					End = new DateTime(2021, 08, 05),
					Id = 3
				},
				new Item
				{
					Begin = new DateTime(2021, 08, 22),
					End = new DateTime(2021, 08, 30),
					Id = 4
				},
			};
		}

		public static void CompareResults4(List<Item> result)
		{
			var expected = new List<Item>
			{
				new Item
				{
					Begin = new DateTime(2021, 08, 01),
					End = new DateTime(2021, 08, 05),
					Id = 3
				},
				new Item
				{
					Begin = new DateTime(2021, 08, 06),
					End = new DateTime(2021, 08, 09),
					Id = 1
				},
				new Item
				{
					Begin = new DateTime(2021, 08, 19),
					End = new DateTime(2021, 08, 21),
					Id = 2
				},
				new Item
				{
					Begin = new DateTime(2021, 08, 22),
					End = new DateTime(2021, 08, 30),
					Id = 4
				},
			};

			CompareLists(expected, result);
		}

		#endregion
		
		#region Samples5

		public static IEnumerable<Item> CreateSampleParents5()
		{
			return new List<Item>
			{
				new Item
				{
					Begin = new DateTime(2021, 08, 06),
					End = new DateTime(2021, 08, 09),
					Id = 1
				},
				new Item
				{
					Begin = new DateTime(2021, 08, 12),
					End = new DateTime(2021, 08, 15),
					Id = 2
				},
			};
		}
				
		public static IEnumerable<Item> CreateSampleChilds5()
		{
			return new List<Item>();
		}

		public static void CompareResults5(List<Item> result)
		{
			var expected = new List<Item>
			{
				new Item
				{
					Begin = new DateTime(2021, 08, 06),
					End = new DateTime(2021, 08, 09),
					Id = 1
				},
				new Item
				{
					Begin = new DateTime(2021, 08, 12),
					End = new DateTime(2021, 08, 15),
					Id = 2
				},
			};

			CompareLists(expected, result);
		}

		#endregion
		
		private static void CompareLists(List<Item> expected, List<Item> result)
		{
			if (expected.Count != result.Count)
			{
				Console.WriteLine($"The List length is incorrect: Expected {expected.Count} but is {result.Count}");
				return;
			}

			for (int i = 0; i < expected.Count; i++)
			{
				if (expected[i].Begin != result[i].Begin)
				{
					Console.WriteLine($"Error in Index {i} at Begin: Expected {expected[i].Begin} but is {result[i].Begin}");
					return;
				}
				if (expected[i].End != result[i].End)
				{
					Console.WriteLine($"Error in Index {i} at End: Expected {expected[i].End} but is {result[i].End}");
					return;
				}
				if (expected[i].Id != result[i].Id)
				{
					Console.WriteLine($"Error in Index {i} at Id: Expected {expected[i].Id} but is {result[i].Id}");
					return;
				}
			}
			Console.WriteLine("Everything is correct.");
		}
	}
}
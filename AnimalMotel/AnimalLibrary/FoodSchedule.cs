using System.Collections.Generic;
/// <summary>
/// Created 2019-03-10
/// Author: Tomas Perers
/// Food schedule used by animals.
/// </summary>
namespace AnimalMotel
{
    public class FoodSchedule
    {
        private List<string> foodDescriptionList;
        public int Count { get => foodDescriptionList.Count; }

        public FoodSchedule()
        {
            foodDescriptionList = new List<string>();
        }

        public FoodSchedule(List<string> foodList)
        {
            foodDescriptionList = foodList;
        }

        /// <summary>
        /// Adds an item to the list.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool AddFoodScheduleItem(string item)
        {
            if (string.IsNullOrEmpty(item))
            {
                return false;
            }
            else
            {
                foodDescriptionList.Add(item);
                return true;
            }
        }

        /// <summary>
        /// Change an item in the list
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool ChangeFoodScheduleItem(string item, int index)
        {
            if (string.IsNullOrEmpty(item))
            {
                return false;
            }
            else if (ValidateIndex(index))
            {
                foodDescriptionList[index] = item;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Delete an item in the list
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool DeleteFoodSchedlueItem(int index)
        {
            if (ValidateIndex(index))
            {
                foodDescriptionList.RemoveAt(index);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Return a string with information if there is no feeding.
        /// </summary>
        /// <returns></returns>
        public string DescribeNoFeedingRequired()
        {
            return "No feeding required";
        }

        /// <summary>
        /// return the feeding schedule.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetFoodSchedule(int index)
        {
            if (Count > 0)
                return foodDescriptionList[index];
            else
                return DescribeNoFeedingRequired();
        }

        /// <summary>
        /// Return the list as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (foodDescriptionList.Count > 0)
            {
                string output = "Food details and feeding schedule are as follows: \n";
                foreach (string food in foodDescriptionList)
                {
                    output += food + "\n";
                }
                return output;
            }
            else
                return DescribeNoFeedingRequired();
        }

        /// <summary>
        /// Validate that the index is correct.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool ValidateIndex(int index)
        {
            if (index >= 0 && index < Count)
                return true;
            else
                return false;
        }
    }
}
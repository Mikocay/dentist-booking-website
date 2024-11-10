namespace swp391_debo_be.Helpers
{
    public class Slot
    {
        private static readonly List<int> definedSlot = new List<int> {7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19};

        public static List<int> GetSlots(List<int> nonAvailableSlots) 
        {
            if (nonAvailableSlots == null)
            {
                return new List<int>();
            }
            List<int> availableSlots = definedSlot;
            foreach (int slot in nonAvailableSlots)
            {
                availableSlots.Remove(slot);
            }

            return availableSlots;
        }
    }
}

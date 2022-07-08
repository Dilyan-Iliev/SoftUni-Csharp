using LocalPractice.Models.Interfaces;

namespace LocalPractice.Models.Abstract_classes
{
    public abstract class Soldier : ISoldier
    {//абстрактен е понеже не ми трябва да създам просто войник, а да създам конкретен тип войник
        protected Soldier(int iD, string firstName, string lastName)
        {//конструктора ми е protected, a не public понеже имам абстрактен клас
            this.ID = iD;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}

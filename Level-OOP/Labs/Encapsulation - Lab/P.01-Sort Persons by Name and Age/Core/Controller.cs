using PracticeForJudge.Core.Interfaces;
using PracticeForJudge.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeForJudge.Core
{
    public class Controller : IController
    {
        public Person CreatePerson(string firstName, string lastName, int age)
        {
            return new Person(firstName, lastName, age);
        }
    }
}

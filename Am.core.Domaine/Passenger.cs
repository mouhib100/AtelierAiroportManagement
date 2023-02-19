﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Am.core.Domaine
{
    internal class Passenger
    {
        public DateTime BirthDate
        {
            get { return BirthDate; }
            set { BirthDate = value; }
        }
        public string PassportNumber { get; set; }
        public string EmailAdresse { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelNumber { get; set; }
        public IList<Passenger> passengers { get; set; }

        public int Age { get; set; }
       

        public override string ToString()
        {
            return "BirthDate:" + BirthDate + ";"
                + "PassportNumber:" + PassportNumber + ";"
                + "EmailAdresse:" + EmailAdresse + ";"
                + "FirstName:" + FirstName + ";"
                + "LastName:" + LastName + ";"
                + "TelNumber:" + TelNumber + ";"
                + "TelNumber:" + TelNumber;
        }

        //Q11.a
        public bool CheckProfile(string lastname, string firstname)
        {
            if (lastname==LastName && firstname==FirstName) 
                return true;
            return false;
        }
        /*
        //Q11.b
        public bool CheckProfile(string lastname, string firstname, string emailAdresse)
        {
            if (lastname == LastName && firstname == FirstName && emailAdresse==EmailAdresse)
                return true;
            return false;
        }
        */
        //Q11.c (on a remplacer les 2 fonctions Q11.a et 11.B - c'est comme un optimisation de code mais il est plus difficle et complexe)
        public bool CheckProfile(string lastname, string firstname, string emailAdresse=null)
        {   
            if (emailAdresse==null)
                return lastname == LastName && firstname == FirstName;
            else 
                return lastname == LastName && firstname == FirstName && emailAdresse==EmailAdresse;
        }

        //question 12 Polymorphisme par héritage
        public virtual string GetPassengerType()
        {
            return "I am a Passenger";
        }

        //Question 13

        public void GetAge(DateTime birthDate, out int calculatedAge)
        {
            // Calculer l'âge en soustrayant la date de naissance de la date actuelle
            int age = DateTime.Now.Year - birthDate.Year;

            // Si la date de naissance n'est pas encore passée cette année, réduire l'âge de 1
            if (DateTime.Now.Month < birthDate.Month || (DateTime.Now.Month == birthDate.Month && DateTime.Now.Day < birthDate.Day))
            {
                age--;
            }

            calculatedAge = age;
        }

        public void GetAge1(Passenger aPassenger)
        {
            DateTime now = DateTime.Now;
            int age = now.Year - aPassenger.BirthDate.Year;

            if (now < aPassenger.BirthDate.AddYears(age))
            {
                age--;
            }

            aPassenger.Age = age;
        }


        public void GetAge2(DateTime birthDate, ref int calculatedAge)
        {
            DateTime now = DateTime.Now;
            int age = now.Year - birthDate.Year;

            if (now < birthDate.AddYears(age))
            {
                age--;
            }

            calculatedAge = age;
        }


    }
}

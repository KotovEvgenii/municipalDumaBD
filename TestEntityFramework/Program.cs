﻿using System;
using System.Linq;
using TestEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TestEntityFramework
{
    class Program
    {
        static void ShowComission()
        {
            MunicipalDumaContext mdc = new MunicipalDumaContext();

            var result = from comis in mdc.FComissions
                         join l_com_pers in mdc.LComissionPeople on comis.FComission1 equals l_com_pers.FComission
                         join people in mdc.FPeople on l_com_pers.FPeople equals people.FPeople
                         select new
                         {
                             id = comis.FComission1,
                             name = comis.Name,
                             nameP = people.Name,
                             surnameP = people.Surname,
                             stat = l_com_pers.Stat,
                             statMain = l_com_pers.StatMain
                         };


            foreach (var x in result)
            {
                string stat, statMain;
                switch (x.stat)
                {
                    case 0:
                        stat = "Работает";
                        break;
                    case 1:
                        stat = "Уволен";
                        break;
                    default:
                        stat = "Статус не определён";
                        break;
                }
                switch (x.statMain)
                {
                    case 0:
                        statMain = "Обычный";
                        break;
                    case 1:
                        statMain = "Председатель";
                        break;
                    default:
                        statMain = "Статус не определён";
                        break;
                }
                Console.WriteLine($"{x.id.ToString(),2} \t {x.name,30} \t {x.nameP,15} \t {x.surnameP,20} \t {stat,20} \t {statMain}");
            }
        }
        static void AddPeople(string name_, string surname_, string address_, string phoneNumber_)
        {
            MunicipalDumaContext mdc = new MunicipalDumaContext();

            var people = new FPerson
            {
                Name = name_,
                Surname = surname_,
                Address = address_,
                PhoneNumber = phoneNumber_
            };

            mdc.FPeople.Add(people);
            mdc.SaveChanges();
        }

        static void AddComission(string nameComiss_)
        {
            MunicipalDumaContext mdc = new MunicipalDumaContext();

            var f_comm = new FComission
            {
                Name = nameComiss_
            };

            mdc.FComissions.Add(f_comm);  
            mdc.SaveChanges();
        }

        /// <summary>
        /// Связь людей и комиссий
        /// "statMain_">0 - обычный слушатель, 1 - председатель
        /// "dateBegin_">дата зачисления в формате 31/01/2022
        /// "comiss_">id - комиссии из таблицы f_comission
        /// "f_people_">id - участника из таблицы f_people
        /// </summary>
        /// <param name="statMain_"></param> 
        /// <param name="dateBegin_"></param> 
        /// <param name="comiss_"></param> 
        /// <param name="f_people_"></param> 
        static void AddLComissionPeople(int statMain_, string dateBegin_, int comiss_, int f_people_)
        {
            MunicipalDumaContext mdc = new MunicipalDumaContext();

            var l_comm_pers = new LComissionPerson
            {
                StatMain = statMain_,
                DateBegin = Convert.ToDateTime(dateBegin_),
                FComission = comiss_,
                FPeople = f_people_
            };

            mdc.LComissionPeople.Add(l_comm_pers);

            mdc.SaveChanges();
        }
        /// <summary>
        /// Показывает отсутствующих на заседания членов определённой комиссии за даты
        /// "dateBegin_">дата начала диапазона в формате 31/01/2022
        /// "dateEnd_">дата конца диапазона в формате 31/01/2022
        /// № комиссии целое число
        /// </summary>
        /// <param name="dateBegin_"></param>
        /// <param name="dateEnd_"></param>
        /// <param name="comiss_"></param>
        static void ShowHowIsAbsent(string dateBegin_, string dateEnd_, int comiss_)
        {
            MunicipalDumaContext mdc = new MunicipalDumaContext();

            var query = from lmw in mdc.Set<LMeetingWork>().Where(x => x.IsAbsent == true)
                        from fm in mdc.Set<FMeeting>().Where(t => t.FMeeting1 == lmw.FMeeting && t.FComission == comiss_ && t.DateTime >= Convert.ToDateTime(dateBegin_) &&
                                                            t.DateTime <= Convert.ToDateTime(dateEnd_))
                        from fc in mdc.Set<FComission>().Where(x => x.FComission1 == fm.FComission)
                        from fp in mdc.Set<FPerson>().Where(x => x.FPeople == lmw.FPeople)
                        select new {fc, lmw, fp, fm };

            foreach (var item in query)
            {
                Console.WriteLine($"Название комиссии: {item.fc.Name} \t Дата Заседания:{item.fm.DateTime} \t Отсутствовал: {item.fp.Name}  {item.fp.Surname}  ");
            }
            
        }
        static void Main(string[] args)
        {
            //ShowComission();
            //AddPeople("Киану","Ривз", "Матрица","00001118877" );
            //AddComission("Комиссия по вооружению");
            //AddLComissionPeople(1, "27/03/2022", 6, 13);
            //AddLComissionPeople(0, "27/03/2022", 6, 1);
            //ShowHowIsAbsent("01/01/2021", "01/06/2021", 1);
        }
    }
}

//Data Source=DESKTOP-SN5T4D0;Initial Catalog=MunicipalDuma;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
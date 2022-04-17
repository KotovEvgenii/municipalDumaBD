using System;
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
                         join l_com_pers in mdc.LComissionPerson on comis.FComissionId equals l_com_pers.FComission
                         join person in mdc.FPerson on l_com_pers.FPerson equals person.FPersonId
                         select new
                         {
                             id = comis.FComissionId,
                             name = comis.Name,
                             nameP = person.Name,
                             surnameP = person.Surname,
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
        
        static void AddPerson(string name_, string surname_, string address_, string phoneNumber_)
        {
            MunicipalDumaContext mdc = new MunicipalDumaContext();

            var people = new FPerson
            {
                Name = name_,
                Surname = surname_,
                Address = address_,
                PhoneNumber = phoneNumber_
            };

            mdc.FPerson.Add(people);
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
        static void AddLComissionPerson(int statMain_, string dateBegin_, int comiss_, int f_people_)
        {
            MunicipalDumaContext mdc = new MunicipalDumaContext();

            var l_comm_pers = new LComissionPerson
            {
                StatMain = statMain_,
                DateBegin = Convert.ToDateTime(dateBegin_),
                FComission = comiss_,
                FPerson = f_people_
            };

            mdc.LComissionPerson.Add(l_comm_pers);

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

            //var query = from lmw in mdc.Set<LMeetingWork>().Where(x => x.IsAbsent == true)
            //            from fm in mdc.Set<FMeeting>().Where(t => t.FMeetingId == lmw.FMeeting && t.FComission == comiss_ && t.DateTime >= Convert.ToDateTime(dateBegin_) &&
            //                                                t.DateTime <= Convert.ToDateTime(dateEnd_))
            //            from fc in mdc.Set<FComission>().Where(x => x.FComissionId == fm.FComission)
            //            from fp in mdc.Set<FPerson>().Where(x => x.FPersonId == lmw.FPerson)
            //            select new {fc, lmw, fp, fm };

            var query = mdc.LMeetingWorks.Where(x => x.IsAbsent == true)
                        .Include(x => x.FPersonNavigation)
                        .Include(x => x.FMeetingNavigation).Where(t => t.FMeetingNavigation.FComission == comiss_ && t.FMeetingNavigation.DateTime >= Convert.ToDateTime(dateBegin_) &&
                                                            t.FMeetingNavigation.DateTime <= Convert.ToDateTime(dateEnd_))
                        .Include(t => t.FMeetingNavigation.FComissionNavigation);
                        //.GroupBy(x => x.FPersonNavigation);

            foreach (var item in query)
            {
                Console.WriteLine(//$"Название комиссии: {item.FMeetingNavigation.FComissionNavigation.Name} \t " +
                                    $"Дата Заседания:{item.FMeetingNavigation.DateTime} \t " +
                                    $"Отсутствовал: {item.FPersonNavigation.Name}  {item.FPersonNavigation.Surname} \t" +
                                    $"Количество пропусков: {item.IsAbsent} ");
                //Console.WriteLine(//$"Название комиссии: {item.FirstOrDefault().FMeetingNavigation.FComissionNavigation.Name} \t " +
                //                    $"Дата Заседания:{item.FirstOrDefault().FMeetingNavigation.DateTime} \t " +
                //                    $"Отсутствовал: {item.FirstOrDefault().FPersonNavigation.Name}  {item.FirstOrDefault().FPersonNavigation.Surname} \t" +
                //                    $"Количество пропусков: {item.FirstOrDefault().IsAbsent} ");
            }
            
        }

        static void ShowCommPerson(int id)
        {
            MunicipalDumaContext mdc = new MunicipalDumaContext();

            var query = mdc.LComissionPerson
                        .Include(l => l.FPersonNavigation).Where(l => l.FPersonNavigation.FPersonId == id)
                        .Include(l => l.FComissionNavigation);

            foreach (var item in query)
            {
                Console.WriteLine($"{item.FPersonNavigation.Name}_{item.FPersonNavigation.Surname} | {item.FComissionNavigation.Name}");
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
            ShowCommPerson(2);
        }
    }
}

//Data Source=DESKTOP-SN5T4D0;Initial Catalog=MunicipalDuma;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
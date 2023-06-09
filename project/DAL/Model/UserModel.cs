﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class UserModel
    {

        public List<user> Get()

        {
            using (HOMEntities db = new HOMEntities())
            {
                return db.users.Where(x => x.Status == 1).ToList();
            }
        }
        public user GetById(string Id)
        {
            using (HOMEntities db = new HOMEntities())
            {
                return db.users.FirstOrDefault(x => x.Id == Id && x.Status == 1);
            }
        }
        public List<user> GetByMobilePhone(string phone)
        {
            using (HOMEntities db = new HOMEntities())
            {
                return db.users.Where(x => x.Mobile_Phone == phone && x.Status == 1).ToList();
            }
        }
        public bool IsExist(string id)
        {
            using (HOMEntities db = new HOMEntities())
            {
                if (db.users.Any(x => x.Id == id))
                    return false;
                return true;
            }
        }
        public bool IsValidId(string id)
        {
            int[] intId = new int[9], check = { 1, 2, 1, 2, 1, 2, 1, 2, 1 };
            for (int i = 0; i < id.Length; i++)
            {
                intId[i] = id[i] - '0';
            }
            int index = 0, sum = 0, subSum = 0,temp=0;
            int[] arr = new int[9];

            for (int i = 0; i < intId.Length; i++)
            {
                arr[index++] = intId[i] * check[i];
            }

            for (int j = 0; j < arr.Length; j++)
            {
                if (arr[j] > 9)
                {
                    temp = arr[j];
                    while (temp > 0)
                    {
                        subSum += temp % 10;
                        temp /= 10;
                    }
                    sum += subSum;
                    subSum = 0;
                }
                else
                {
                    sum += arr[j];
                }
            }
            if (sum % 10 != 0 || sum == 0)
                return false;
            return true;

        }
        public bool IsValidName(string name)
        {
            return name.Count() > 5;
        }
        public bool IsValidMObilePhone(string number)
        {
            return number.Count() == 10 && number[0]=='0' && number[1]=='5';
        }
        public bool IsValidPhone(string number)
        {
            return number.Count()>=6 || number.Count() <=9 ;
        }
        public bool IsValidDate(DateTime date)
        {
            return date <= DateTime.Now;
        }
        public bool Validation(user user)
        {
            DateTime positive = (DateTime)user.PositiveResultDate;
            DateTime cure = (DateTime)user.CureDate;
            return IsValidPhone(user.Phone) && IsValidMObilePhone(user.Mobile_Phone) &&
               IsValidDate(user.Birth_Date) && IsValidId(user.Id) && IsValidName(user.Name)&& IsValidDate(positive) && IsValidDate(cure);
        }

        public user Post(user user)
        {
            using (HOMEntities db = new HOMEntities())
            {
                user.Status = 1;
                if (!Validation(user)) return null;

                user = db.users.Add(user);

                try
                {
                    db.SaveChanges();
                    return user;
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
        }
        //פונ' זו מאפשרת  עדכון רשומות וגם מחיקה ע"י שינוי הסטטוס ל0
        public user Put(user user)
        {
            using (HOMEntities db = new HOMEntities())
            {
                user newuser = db.users.FirstOrDefault(x => x.Id == user.Id);
                newuser.Name = user.Name;
                newuser.Phone = user.Phone;
                newuser.Mobile_Phone = user.Mobile_Phone;
                newuser.Address = user.Address;
                newuser.PositiveResultDate = user.PositiveResultDate;
                newuser.CureDate = user.CureDate;
                newuser.Status = user.Status;
                if (!Validation(newuser)) return null;
                try
                {
                    db.SaveChanges();
                    return user;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}

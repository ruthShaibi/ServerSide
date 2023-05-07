using System;
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
        public user Get(string Id)
        {
            using (HOMEntities db = new HOMEntities())
            {
                return db.users.FirstOrDefault(x => x.Id == Id && x.Status == 1);
            }
        }
        public bool IsExist(string id)
        {
            using (HOMEntities db = new HOMEntities())
            {
                return db.users.Any(x => x.Id == id);
            }
        }
        public bool IsValidId(string id)
        {
            char[] ch = id.ToCharArray(), check = { '1', '2', '1', '2', '1', '2', '1', '2', '1' };
            int intId = int.Parse(id);
            int index = 0, sum = 0, temp = 0, subSum = 0;
            int[] arr = new int[9];
            for (int i = 0; i < ch.Length; i++)
            {
                arr[index++] = (ch[i] - '0') * (check[i] - '0');
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
            if (sum % 10 != 0)
                return false;
            return true;

        }
        public bool IsValidName(string name)
        {
            return !(name.Count() < 5);
        }
        public bool IsValidPhone(string number)
        {
            return !(number.Count() < 10 || number.Count() > 10);
        }
        public bool IsValidDate(DateTime date)
        {
            return date <= DateTime.Now;
        }
        public bool Validation(user user)
        {
            return IsValidPhone(user.Phone) && IsValidPhone(user.Mobile_Phone) &&
               IsValidDate(user.Birth_Date) && IsValidId(user.Id);
        }

        public user Post(user user)
        {
            using (HOMEntities db = new HOMEntities())
            {
                user.Status = 1;
                if (!Validation(user)) return null;
                
                user = db.users.Add(user);
                db.SaveChanges();
                return user;
            }
        }

    }
}

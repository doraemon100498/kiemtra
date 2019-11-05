using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.Model
{
    class Contacts
    {
        public string Group { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address {get;set;}
        public static Contacts GetContact(string pathData, string Name)
        {
            if (File.Exists(pathData))
            {
                var arrayLines = File.ReadAllLines(pathData);
                foreach (var line in arrayLines)
                {
                    var lsValue = line.Split(new char[] { '#' });
                    var Contacts = new Contacts
                    {
                        Group = lsValue[0],
                        Name = lsValue[1],
                        Email = lsValue[2],
                        Phone = lsValue[3],
                        Address=lsValue[4]
                    };
                    if (Contacts.Name == Name)
                        return Contacts;
                }
            }
            return null;
        }
        public static ArrayList GetListGroup(string pathData)
        {
            if (File.Exists(pathData))
            {
                ArrayList ds = new ArrayList();
                var arrayLines = File.ReadAllLines(pathData);
                foreach (var line in arrayLines)
                {
                    var lsValue = line.Split(new char[] { '#' });
                    if (!ds.Contains(lsValue[0]))
                    {
                        ds.Add(lsValue[0]);
                    }
                }
                return ds;
            }
            return null;
        }
        public static List<Contacts> GetListContactFromFile(string pathData)
        {
            var arrayLines = File.ReadAllLines(pathData);
            List<Contacts> ketQua = new List<Contacts>();
            foreach (var line in arrayLines)
            {
                var lsValue = line.Split(new char[] { '#' });
                ketQua.Add(new Contacts
                {
                    Group = lsValue[0],
                    Name = lsValue[1],
                    Email = lsValue[2],
                    Phone = lsValue[3],
                    Address = lsValue[4]
                });
            }
            return ketQua;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementSystem.Model;
using System.Web.Security;

namespace ManagementSystem.DB.DBOperations
{
    public class AttendeeRepository
    {
        public int AddAttendee(AttendeeModel model)
        {
            using (var context = new SeminarDBEntities())
            {
                if (context.Attendee.Any(x => x.Email == model.Email))
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    return 0;
                }
                if (context.Attendee.Any(x => x.Phone == model.Phone))
                {
                    FormsAuthentication.SetAuthCookie(model.Phone, false);
                    return 0;
                }
                Attendee att = new Attendee()
                {
                    Name = model.Name,
                    DateOfBirth = model.DateOfBirth,
                    Email = model.Email,
                    Gender = model.Gender,
                    Occupation = model.Occupation,
                    Phone = model.Phone,
                    Address = model.Address,
                    IsAvailable = model.IsAvailable,
                    
                };

                context.Attendee.Add(att);

                context.SaveChanges();

                return att.AttendeeID;
            }
        }

        public List<AttendeeModel> GetAllAttendee()
        {
            using (var context = new SeminarDBEntities())
            {
                var result = context.Attendee
                    .Select(x => new AttendeeModel() 
                    {
                        AttendeeID = x.AttendeeID,
                        Name = x.Name,
                        DateOfBirth = x.DateOfBirth,
                        Email = x.Email,
                        Gender = x.Gender,
                        Occupation = x.Occupation,
                        Phone = x.Phone,
                        Address = x.Address,
                        IsAvailable = x.IsAvailable,

                    }).ToList();

                return result;
            }
        }

        public AttendeeModel GetAttendee(int id)
        {
            using (var context = new SeminarDBEntities())
            {
                var result = context.Attendee
                    .Where(x => x.AttendeeID == id)
                    .Select(x => new AttendeeModel()
                    {
                        AttendeeID = x.AttendeeID,
                        Name = x.Name,
                        DateOfBirth = x.DateOfBirth,
                        Email = x.Email,
                        Gender = x.Gender,
                        Occupation = x.Occupation,
                        Phone = x.Phone,
                        Address = x.Address,
                        IsAvailable = x.IsAvailable,
                    }).FirstOrDefault();

                return result;
            }
        }

        public bool UpdateAttendee(int id, AttendeeModel model)
        {
            using (var context = new SeminarDBEntities())
            {
                var attendee = new Attendee();

                attendee.AttendeeID = model.AttendeeID;
                attendee.Name = model.Name;
                attendee.DateOfBirth = model.DateOfBirth;
                attendee.Email = model.Email;
                attendee.Gender = model.Gender;
                attendee.Occupation = model.Occupation;
                attendee.Phone = model.Phone;
                attendee.Address = model.Address;
                attendee.IsAvailable = model.IsAvailable;

                context.Entry(attendee).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteAttendee(int id)
        {
            using (var context = new SeminarDBEntities())
            {
                var att = new Attendee()
                {
                    AttendeeID = id
                };

                try
                {
                    context.Entry(att).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
                    return true;
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.InnerException.Message);
                    return false;
                }
            }
        }
    }
}

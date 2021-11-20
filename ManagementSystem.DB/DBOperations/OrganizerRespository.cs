using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using ManagementSystem.Model;

namespace ManagementSystem.DB.DBOperations
{
    public class OrganizerRespository
    {
        public int AddOrganizer(OrganizerModel model)
        {
            using (var context = new SeminarDBEntities())
            {
                if (context.Organizer.Any(x => x.OrganizerEmail == model.OrganizerEmail))
                {
                    FormsAuthentication.SetAuthCookie(model.OrganizerEmail, false);
                    return 0;
                }
                if (context.Organizer.Any(x => x.OrganizerPhone == model.OrganizerPhone))
                {
                    FormsAuthentication.SetAuthCookie(model.OrganizerPhone, false);
                    return 0;
                }
                Organizer org = new Organizer()
                {
                    OrganizerID = model.OrganizerID,
                    OrganizerName = model.OrganizerName,
                    OrganizerEmail = model.OrganizerEmail,
                    OrganizerPhone = model.OrganizerPhone,
                    OrganizerAddress = model.OrganizerPhone,
                    IsAvailable = model.IsAvailable

                };

                context.Organizer.Add(org);

                context.SaveChanges();

                return org.OrganizerID;
            }
        }
        public List<OrganizerModel> GetAllOrganizer()
        {
            using (var context = new SeminarDBEntities())
            {
                var result = context.Organizer
                    .Select(x => new OrganizerModel()
                    {
                        OrganizerID = x.OrganizerID,
                        OrganizerName = x.OrganizerName,
                        OrganizerEmail = x.OrganizerEmail,
                        OrganizerPhone = x.OrganizerPhone,
                        OrganizerAddress = x.OrganizerPhone,
                        IsAvailable = x.IsAvailable

                    }).ToList();

                return result;
            }
        }

        public OrganizerModel GetOrganizer(int id)
        {
            using (var context = new SeminarDBEntities())
            {
                var result = context.Organizer
                    .Where(x => x.OrganizerID == id)
                    .Select(x => new OrganizerModel()
                    {
                        OrganizerID = x.OrganizerID,
                        OrganizerName = x.OrganizerName,
                        OrganizerEmail = x.OrganizerEmail,
                        OrganizerPhone = x.OrganizerPhone,
                        OrganizerAddress = x.OrganizerPhone,
                        IsAvailable = x.IsAvailable

                    }).FirstOrDefault();

                return result;
            }
        }
        public bool UpdateOrganizer(int id, OrganizerModel model)
        {
            using (var context = new SeminarDBEntities())
            {

                var organizer = new Organizer();
                organizer.OrganizerID = model.OrganizerID;
                organizer.OrganizerName = model.OrganizerName;
                organizer.OrganizerEmail = model.OrganizerEmail;
                organizer.OrganizerPhone = model.OrganizerPhone;
                organizer.OrganizerAddress = model.OrganizerPhone;
                organizer.IsAvailable = model.IsAvailable;

                context.Entry(organizer).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteOrganizer(int id)
        {
            using (var context = new SeminarDBEntities())
            {
                var org = new Organizer()
                {
                    OrganizerID = id
                };

                try
                {
                    context.Entry(org).State = System.Data.Entity.EntityState.Deleted;
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

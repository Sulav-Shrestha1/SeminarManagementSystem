using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using ManagementSystem.Model;

namespace ManagementSystem.DB.DBOperations
{
    public class SeminarRespository
    {
        public int AddSeminar(SeminarModel model)
        {
            using (var context = new SeminarDBEntities())
            {
                if (context.Seminar.Any(x => x.SeminarTitle == model.SeminarTitle))
                {
                    FormsAuthentication.SetAuthCookie(model.SeminarTitle, false);
                    return 0;
                }
                Seminar sem = new Seminar()
                {
                    SeminarTitle = model.SeminarTitle,
                    SeminarTeacher = model.SeminarTeacher,
                    SeminarRoom = model.SeminarRoom,
                    SeminarDate = model.SeminarDate,
                    SeminarDesc = model.SeminarDesc,
                    SeminarStartTime = model.SeminarStartTime,
                    SeminarEndTime = model.SeminarEndTime,
                    SeminarType = model.SeminarType,
                    IsAvailable = model.IsAvailable,
                    OrganizerID = model.OrganizerID

                };

                context.Seminar.Add(sem);

                context.SaveChanges();

                return sem.SeminarID;
            }
        }
        public List<SeminarModel> GetAllSeminar()
        {
            using (var context = new SeminarDBEntities())
            {
                var result = context.Seminar
                    .Select(x => new SeminarModel()
                    {
                        SeminarID = x.SeminarID,
                        SeminarTitle = x.SeminarTitle,
                        SeminarTeacher = x.SeminarTeacher,
                        SeminarRoom = x.SeminarRoom,
                        SeminarDate = x.SeminarDate,
                        SeminarDesc = x.SeminarDesc,
                        SeminarStartTime = x.SeminarStartTime,
                        SeminarEndTime = x.SeminarEndTime,
                        SeminarType = x.SeminarType,
                        IsAvailable = x.IsAvailable,
                        Organizer = new OrganizerModel()
                        {
                            OrganizerName = x.Organizer.OrganizerName
                        }
                    }).ToList();

                return result;
            }
        }

        public SeminarModel GetSeminar(int id)
        {
            using (var context = new SeminarDBEntities())
            {
                var result = context.Seminar
                    .Where(x => x.SeminarID == id)
                    .Select(x => new SeminarModel()
                    {
                        SeminarID = x.SeminarID,
                        SeminarTitle = x.SeminarTitle,
                        SeminarTeacher = x.SeminarTeacher,
                        SeminarRoom = x.SeminarRoom,
                        SeminarDate = x.SeminarDate,
                        SeminarDesc = x.SeminarDesc,
                        SeminarStartTime = x.SeminarStartTime,
                        SeminarEndTime = x.SeminarEndTime,
                        SeminarType = x.SeminarType,
                        IsAvailable = x.IsAvailable,
                        Organizer = new OrganizerModel()
                        {
                            OrganizerName = x.Organizer.OrganizerName
                        }


                    }).FirstOrDefault();

                return result;
            }
        }
        public bool UpdateSeminar(int id, SeminarModel model)
        {
            using (var context = new SeminarDBEntities())
            {
                var seminar = new Seminar();
                seminar.SeminarID = model.SeminarID;
                seminar.SeminarTitle = model.SeminarTitle;
                seminar.SeminarTeacher = model.SeminarTeacher;
                seminar.SeminarRoom = model.SeminarRoom;
                seminar.SeminarDate = model.SeminarDate;
                seminar.SeminarDesc = model.SeminarDesc;
                seminar.SeminarStartTime = model.SeminarStartTime;
                seminar.SeminarEndTime = model.SeminarEndTime;
                seminar.SeminarType = model.SeminarType;
                seminar.IsAvailable = model.IsAvailable;
                seminar.OrganizerID = model.OrganizerID;

                context.Entry(seminar).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteSeminar(int id)
        {
            using (var context = new SeminarDBEntities())
            {
                var sem = new Seminar()
                {
                    SeminarID = id
                };
                try
                {
                    context.Entry(sem).State = System.Data.Entity.EntityState.Deleted;
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

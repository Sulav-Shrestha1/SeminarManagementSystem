using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementSystem.Model;

namespace ManagementSystem.DB.DBOperations
{
    public class AttendanceRepository
    {
        public int AddAttendance(AttendanceModel model)
        {
            using (var context = new SeminarDBEntities())
            {
                Attendance att = new Attendance()
                {
                    AttendanceID = model.AttendanceID,
                    SeminarID = model.SeminarID,
                    AttendeeID = model.AttendeeID,
                    IsAvailable = model.IsAvailable

                };

                context.Attendance.Add(att);

                context.SaveChanges();

                return att.AttendanceID;
            }
        }
        public List<AttendanceModel> GetAllAttendance()
        {
            using (var context = new SeminarDBEntities())
            {
                var result = context.Attendance
                    .Select(x => new AttendanceModel()
                    {
                        AttendanceID = x.AttendanceID,
                        IsAvailable = x.IsAvailable,
                        Seminar = new SeminarModel()
                        {
                            SeminarTitle = x.Seminar.SeminarTitle
                        },
                        Attendee = new AttendeeModel()
                        {
                            Name = x.Attendee.Name
                        }

                    }).ToList();

                return result;
            }
        }

        public AttendanceModel GetAttendance(int id)
        {
            using (var context = new SeminarDBEntities())
            {
                var result = context.Attendance
                    .Where(x => x.AttendanceID == id)
                    .Select(x => new AttendanceModel()
                    {
                        AttendanceID = x.AttendanceID,
                        IsAvailable = x.IsAvailable,
                        Seminar = new SeminarModel()
                        {
                            SeminarTitle = x.Seminar.SeminarTitle
                        },
                        Attendee = new AttendeeModel()
                        {
                            Name = x.Attendee.Name
                        }

                    }).FirstOrDefault();

                return result;
            }
        }
        public bool UpdateAttendance(int id, AttendanceModel model)
        {
            using (var context = new SeminarDBEntities())
            {
                var attendance = new Attendance();

                attendance.AttendanceID = model.AttendanceID;
                attendance.SeminarID = model.SeminarID;
                attendance.AttendeeID = model.AttendeeID;
                attendance.IsAvailable = model.IsAvailable;

                context.Entry(attendance).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteAttendance(int id)
        {
            using (var context = new SeminarDBEntities())
            {
                var att = new Attendance()
                {
                    AttendanceID = id
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

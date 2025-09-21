using Microsoft.EntityFrameworkCore;
using ClinicAppointmentSystem.Models;
using System.Xml.Linq;

namespace PracticeWeb
{
    public class ClinicDbContent : DbContext
    {
        public ClinicDbContent(DbContextOptions<ClinicDbContent> options) : base(options)
        {
        }

        public DbSet<ClinicDb> datas { get; set; }
    }
}

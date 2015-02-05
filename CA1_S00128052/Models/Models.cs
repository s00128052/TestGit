using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

public enum Gender{Male, Female}

namespace CA1_S00128052.Models
{
    public class CampDbInitialiser:DropCreateDatabaseAlways<CampDb>
    {
        protected override void Seed(CampDb context)
        {
            var Camps = new List<Camp>(){
                new Camp(){
                    CampTitle="Cavan GAA Summer Camp",
                    CampStartDate=DateTime.Parse("10/06/2014"),
                    CampChildren=new List<Child>(){
                        new Child(){
                            ChildName="Jack Black",
                            ChildGender=Gender.Male
                        },
                        new Child(){
                            ChildName="Katie Reach",
                            ChildGender=Gender.Female
                        }
                    }
                },
                new Camp(){
                    CampTitle="All Ireland Band Camp",
                    CampStartDate=DateTime.Parse("05/08/14")
                },
                new Camp(){
                    CampTitle="Mayo GAA Summer Camp",
                    CampStartDate=DateTime.Parse("20/06/14")
                }  
            };
            Camps.ForEach(cmp => context.Camps.Add(cmp));
            context.SaveChanges();
            base.Seed(context);
        }
    }

    public class CampDb:DbContext
    {
        public DbSet<Camp> Camps { get; set; }
        public DbSet<Child> Children { get; set; }
        public CampDb():base("CampDatabaseConn") { }
    }

    public class Camp
    {
        [Key]
        public int CampId { get; set; }
        [Display(Name="Title")]
        public string CampTitle { get; set; }
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CampStartDate { get; set; }
        [Display(Name = "Children")]
        public List<Child> CampChildren { get; set; }
    }

    public class Child
    {
        [Key]
        public int ChildId { get; set; }
        [Display(Name = "Name")]
        public string ChildName { get; set; }
        [Display(Name = "Gender")]
        public Gender ChildGender { get; set; }
        [Display(Name = "Camp")]
        public Camp ChildCamp { get; set; }
    }
}
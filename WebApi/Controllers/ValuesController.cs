using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.OData;

namespace WebApi.Controllers
{
     //[Authorize]
    [RoutePrefix("api/values")]
     [EnableCors("*", "*", "*", SupportsCredentials = true)]
    public class ValuesController : ApiController
    {
        [Route("getAcademicStaff")]
        public List<AcademicStaff> GetAcademicStaff(string userId, string userPassword)
        {
            List<AcademicStaff> academicStaffList = new List<AcademicStaff>();
            try
            {
                foreach (academicstaffentry academicstaffentry in Config.ReturnNav().academicstaffentry)
                {
                    AcademicStaff academicStaff = new AcademicStaff();
                    academicStaff.IdNumber = academicstaffentry.ID_Passport_No;
                    academicStaff.SurName = academicstaffentry.Surname;
                    academicStaff.MiddleName = academicstaffentry.Mddle_Name;
                    academicStaff.FirstName = academicstaffentry.First_Name;
                    academicStaff.EthnicBackground = academicstaffentry.Ethnic_Background;
                    string str1 = Convert.ToDateTime((object)academicstaffentry.Date_of_Birth).ToString("dd-MM-yyyy");
                    academicStaff.DateOfBirth = str1.Replace("-", "/").Trim();
                    academicStaff.HomeCounty = academicstaffentry.Home_County;
                    academicStaff.ProgramDomain = academicstaffentry.Program_Domain;
                    string str2 = Convert.ToDateTime((object)academicstaffentry.Date_of_first_Appointment).ToString("dd-MM-yyyy");
                    academicStaff.DateOfFirstAppointment = str2.Replace("-", "/").Trim();
                    academicStaff.Rank = academicstaffentry.Rank;
                    academicStaff.HighestAcademicQualification = academicstaffentry.Highest_Academic_Qualification;
                    academicStaff.PayrollNo = academicstaffentry.Payroll_No;
                    academicStaff.TermsOfService = academicstaffentry.Terms_of_Service;
                    academicStaff.Campus = academicstaffentry.Campus;
                    academicStaff.Gender = academicstaffentry.Gender;
                    academicStaff.Nationality = academicstaffentry.Nationality;
                    academicStaff.DisabilityDescription = academicstaffentry.Disability_Description;
                    academicStaff.DisabilityRegistrationCode = academicstaffentry.Disability_Registration_Code;
                    academicStaffList.Add(academicStaff);
                }
            }
            catch (Exception ex)
            {
            }
            return academicStaffList;
        }

        [Route("getLibraryStaff")]
        public List<LibraryStaff> GetLibraryStaff(string userId, string userPassword)
        {
            List<LibraryStaff> libraryStaffList = new List<LibraryStaff>();
            try
            {
                foreach (Library_Staff libraryStaff1 in Config.ReturnNav().Library_Staff)
                {
                    LibraryStaff libraryStaff2 = new LibraryStaff();
                    libraryStaff2.IdNo = libraryStaff1.Id_Number_Passport_No;
                    libraryStaff2.FirstName = libraryStaff1.First_Name;
                    libraryStaff2.MiddleName = libraryStaff1.Middle_Name;
                    libraryStaff2.LastName = libraryStaff1.Last_Name;
                    libraryStaff2.Position = libraryStaff1.Position;
                    string str = Convert.ToDateTime((object)libraryStaff1.Date_of_Birth).ToString("dd-MM-yyyy");
                    libraryStaff2.DateOfBirth = str.Replace("-", "/").Trim();
                    libraryStaff2.HighestAcademicQualification = libraryStaff1.Highest_Academic_Qualification;
                    libraryStaff2.Campus = libraryStaff1.Campus;
                    libraryStaffList.Add(libraryStaff2);
                }
            }
            catch (Exception ex)
            {
            }
            return libraryStaffList;
        }

        [Route("getNonAcademicStaff")]
        public List<NonAcademicStaff> GetNonAcademicStaff(string userId, string userPassword)
        {
            List<NonAcademicStaff> nonAcademicStaffList = new List<NonAcademicStaff>();
            try
            {
                foreach (GeneralStaff generalStaff in Config.ReturnNav().GeneralStaff)
                    nonAcademicStaffList.Add(new NonAcademicStaff()
                    {
                        IDNo = generalStaff.ID_Passport_No,
                        Surname = generalStaff.Surname,
                        MiddleName = generalStaff.Mddle_Name,
                        FirstName = generalStaff.First_Name,
                        Gender = generalStaff.Gender,
                        EthnicBackground = generalStaff.Ethnic_Background,
                        DateOfBirth = Convert.ToDateTime((object)generalStaff.Date_of_Birth).ToString("yyyy-MM-dd"),
                        HomeCounty = generalStaff.Home_County,
                        Category = generalStaff.Category,
                        PayrollNo = generalStaff.PayrollNo,
                        Campus = generalStaff.Campus,
                        EntryNo = generalStaff.Id
                    });
            }
            catch (Exception ex)
            {
            }
            return nonAcademicStaffList;
        }

        [Route("getCases")]
        public List<Discipline> GetCases(string userId, string userPassword)
        {
            List<Discipline> disciplineList = new List<Discipline>();
            try
            {
                foreach (DisciplineCases disciplineCase in Config.ReturnNav().DisciplineCases)
                {
                    Discipline discipline1 = new Discipline();
                    discipline1.CaseId = string.Concat((object)disciplineCase.Case_Id);
                    discipline1.StudentId = disciplineCase.Student_Id;
                    //discipline1.StudentName = disciplineCase.Student_Name;
                    discipline1.Description = disciplineCase.Case_Description;
                    Discipline discipline2 = discipline1;
                    DateTime dateTime = Convert.ToDateTime((object)disciplineCase.Date);
                    string str1 = dateTime.ToString("yyyy-MM-dd");
                    discipline2.CaseDate = str1;
                    discipline1.Verdict = disciplineCase.Verdict_Category;
                    Discipline discipline3 = discipline1;
                    dateTime = Convert.ToDateTime((object)disciplineCase.Verdict_Date);
                    string str2 = dateTime.ToString("yyyy-MM-dd");
                    discipline3.VerdictDate = str2;
                    disciplineList.Add(discipline1);
                }
            }
            catch (Exception ex)
            {
            }
            return disciplineList;
        }
        [Route("getstudents")]
        public List<Student> Get(string userId, string userPassword)
        {
            List<Student> studentList = new List<Student>();
            try
            {
                foreach (studentEnrolmentList studentEnrolment in Config.ReturnNav().studentEnrolmentList)
                {
                    Student student = new Student();
                    //student.enrolmentId = studentEnrolment.Entry_No;
                    student.idNumber = studentEnrolment.ID_Passport_Birth_Certificate;
                    student.Surname = studentEnrolment.Surname;
                    student.firstName = studentEnrolment.First_Name;
                    student.middleName = studentEnrolment.Middle_Name;
                    student.gender = studentEnrolment.Gender;
                    string str1 = Convert.ToDateTime((object)studentEnrolment.Date_of_Birth).ToString("dd-MM-yyyy");
                    student.dob = str1.Replace("-", "/").Trim();
                    student.homeCounty = studentEnrolment.Home_County;
                    student.ethnicBackground = studentEnrolment.Ethnic_Background;
                    student.nationality = studentEnrolment.Nationality_Code;
                    student.sponsorship = studentEnrolment.Sponsorship;
                    student.disabilityType = studentEnrolment.Disability_Type;
                    student.yearOfStudy = studentEnrolment.Year_of_Study;
                    student.disabilityCode = studentEnrolment.Disability_Code;
                    student.personWithDisability = studentEnrolment.Person_With_Disability.ToString();
                    student.disability = studentEnrolment.Disability;
                    student.ethnicBackground = studentEnrolment.Ethnic_Background;
                    student.myProgram = studentEnrolment.Program;
                    student.programLevel = studentEnrolment.Program_Level;
                    string str2 = Convert.ToDateTime((object)studentEnrolment.Date_of_Admission).ToString("dd-MM-yyyy");
                    student.dateOfAdmission = str2.Replace("-", "/").Trim();
                    student.nationalityName = studentEnrolment.Nationality_Name;
                    student.campus = studentEnrolment.Campus_Code;
                    student.admNo = studentEnrolment.Admission_No;
                    studentList.Add(student);
                }
            }
            catch (Exception ex)
            {
            }
            return studentList;
        }

        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public StudentJson POST([FromBody] StudentJson value)
        {
            List<string[]> data = value.data;
            StudentJson studentJson = new StudentJson();
            return value;
        }

        [Route("addStudent")]
        public StudentJson AddStudent([FromBody] StudentJson value)
        {
            List<string[]> data = value.data;
            List<string[]> strArrayList = new List<string[]>();
            foreach (string[] strArray1 in data)
            {
                try
                {
                    int yearOfStudy = 0;
                    bool flag = false;
                    string str1 = "";
                    string lower = strArray1[6].Trim().ToLower();
                    int gender = 1;
                    if (lower == "male")
                        gender = 0;
                    else if (lower == "female")
                        gender = 1;
                    else if (lower == "intersex")
                    {
                        gender = 2;
                    }
                    else
                    {
                        flag = true;
                        str1 = "Please enter a valid gender. The only options are (male, female, intersex)";
                    }
                    string str2 = strArray1[15].Trim();
                    int sponsorship = 1;
                    try
                    {
                        sponsorship = Convert.ToInt32(str2);
                        if (sponsorship > 2 || sponsorship < 1)
                            throw new Exception();
                        --sponsorship;
                    }
                    catch (Exception ex)
                    {
                        flag = true;
                        str1 = "Please enter a valid sponsorship code. The only options are (01 for government, 02 for self sponsored)";
                    }
                    string admissionNo = string.IsNullOrEmpty(strArray1[1]) ? "" : strArray1[1];
                    if (string.IsNullOrEmpty(strArray1[0]))
                    {
                        flag = true;
                        str1 = "Birth Certificate No/ID No/Passport No is mandatory";
                    }
                    else if (string.IsNullOrEmpty(strArray1[2]) && string.IsNullOrEmpty(strArray1[3]) || string.IsNullOrEmpty(strArray1[3]) && string.IsNullOrEmpty(strArray1[4]) || string.IsNullOrEmpty(strArray1[2]) && string.IsNullOrEmpty(strArray1[4]))
                    {
                        flag = true;
                        str1 = "A student must have at least two names";
                    }
                    DateTime dob = new DateTime();
                    try
                    {
                        dob = DateTime.FromOADate(Convert.ToDouble(strArray1[7]));
                    }
                    catch (Exception ex)
                    {
                        flag = true;
                        str1 = "Please provide a valid value for date of birth";
                    }
                    try
                    {
                        yearOfStudy = Convert.ToInt32(strArray1[5]);
                        if (yearOfStudy >= 1)
                        {
                            if (yearOfStudy <= 10) ;

                        }
                        throw new Exception();
                    }
                    catch (Exception ex)
                    {
                        flag = true;
                        str1 = "Please provide a valid value for year of study";
                    }

                    DateTime dateOfAdmission = new DateTime();
                    try
                    {
                        dateOfAdmission = DateTime.FromOADate(Convert.ToDouble(strArray1[12]));
                    }
                    catch (Exception ex)
                    {
                        flag = true;
                        str1 = "Please provide a valid value for date of admission";
                    }
                    DateTime now = DateTime.Now;
                    if (!flag)
                    {
                        if (dateOfAdmission > now)
                        {
                            flag = true;
                            str1 = "Date of admission cannot be earlier than today";
                        }
                        if (dob > now)
                        {
                            flag = true;
                            str1 = "Date of birth cannot be earlier than today";
                        }
                    }
                    if (!flag)
                    {
                        string idPassport = string.IsNullOrEmpty(strArray1[0]) ? "" : strArray1[0];
                        string surname = string.IsNullOrEmpty(strArray1[4]) ? "" : strArray1[4];
                        string middleName = string.IsNullOrEmpty(strArray1[3]) ? "" : strArray1[3];
                        string firstName = string.IsNullOrEmpty(strArray1[2]) ? "" : strArray1[2];
                        string ethnicBckground = string.IsNullOrEmpty(strArray1[10]) ? "" : strArray1[10];
                        string nationality = string.IsNullOrEmpty(strArray1[8]) ? "" : strArray1[8];
                        string homeCounty = string.IsNullOrEmpty(strArray1[9]) ? "" : strArray1[9];
                        string disabilityCode = string.IsNullOrEmpty(strArray1[14]) ? "" : strArray1[14];
                        string myProgram = string.IsNullOrEmpty(strArray1[11]) ? "" : strArray1[11];
                        string campusCode;
                        try
                        {
                            campusCode = string.IsNullOrEmpty(strArray1[16]) ? "" : strArray1[16];
                        }
                        catch (Exception ex)
                        {
                            campusCode = "";
                        }
                        string disabilityDescription = string.IsNullOrEmpty(strArray1[13]) ? "" : strArray1[13];
                        string str3 = new Config().ObjNav().AddStudentDraft(idPassport, admissionNo, surname, middleName, firstName, gender, dob, homeCounty, ethnicBckground, nationality, sponsorship, yearOfStudy, disabilityDescription, disabilityCode, myProgram, dateOfAdmission, campusCode, value.userUserName, value.userPassword);
                        if (str3 != "success")
                        {
                            string[] strArray2 = new string[strArray1.Length + 1];
                            for (int index = 0; index < strArray1.Length; ++index)
                            {
                                strArray2[index] = strArray1[index];
                                if (index == 7 || index == 12)
                                {
                                    try
                                    {
                                        string str4 = DateTime.FromOADate(Convert.ToDouble(strArray1[index])).ToString("dd-MM-yy");
                                        strArray2[index] = str4;
                                    }
                                    catch (Exception ex)
                                    {
                                        strArray2[index] = strArray1[index];
                                    }
                                }
                            }
                            strArray2[strArray1.Length] = str3;
                            strArrayList.Add(strArray2);
                        }
                    }
                    else
                    {
                        string[] strArray2 = new string[strArray1.Length + 1];
                        for (int index = 0; index < strArray1.Length; ++index)
                        {
                            strArray2[index] = strArray1[index];
                            if (index == 7 || index == 12)
                            {
                                try
                                {
                                    string str3 = DateTime.FromOADate(Convert.ToDouble(strArray1[index])).ToString("dd-MM-yy");
                                    strArray2[index] = str3;
                                }
                                catch (Exception ex)
                                {
                                    strArray2[index] = strArray1[index];
                                }
                            }
                        }
                        strArray2[strArray1.Length] = str1;
                        strArrayList.Add(strArray2);
                    }
                }
                catch (Exception ex)
                {
                    string[] strArray2 = new string[strArray1.Length + 1];
                    for (int index = 0; index < strArray1.Length; ++index)
                        strArray2[index] = strArray1[index];
                    strArray2[strArray1.Length] = ex.Message;
                    strArrayList.Add(strArray2);
                }
            }
            StudentJson studentJson = new StudentJson();
            studentJson.data = strArrayList;
            string columnMap = value.column_map;
            studentJson.column_map = columnMap;
            return studentJson;
        }

        [Route("addAcademicStaff")]
        public StudentJson AddAcademicStaff([FromBody] StudentJson value)
        {
            List<string[]> data = value.data;
            List<string[]> strArrayList = new List<string[]>();
            foreach (string[] strArray1 in data)
            {
                try
                {
                    string str1 = "";
                    bool flag = false;
                    string idNumber = "";
                    try
                    {
                        idNumber = string.IsNullOrEmpty(strArray1[0].Trim()) ? "" : strArray1[0].Trim();
                    }
                    catch (Exception ex)
                    {
                    }
                    string payrollNo = "";
                    try
                    {
                        payrollNo = string.IsNullOrEmpty(strArray1[1].Trim()) ? "" : strArray1[1].Trim();
                    }
                    catch (Exception ex)
                    {
                    }
                    string firstName = "";
                    try
                    {
                        firstName = string.IsNullOrEmpty(strArray1[2].Trim()) ? "" : strArray1[2].Trim();
                    }
                    catch (Exception ex)
                    {
                    }
                    string middleName = "";
                    try
                    {
                        middleName = string.IsNullOrEmpty(strArray1[3].Trim()) ? "" : strArray1[3].Trim();
                    }
                    catch (Exception ex)
                    {
                    }
                    string lastName = "";
                    try
                    {
                        lastName = string.IsNullOrEmpty(strArray1[4].Trim()) ? "" : strArray1[4].Trim();
                    }
                    catch (Exception ex)
                    {
                    }
                    if (string.IsNullOrEmpty(idNumber))
                    {
                        flag = true;
                        str1 = "ID No/Passport No is mandatory";
                    }
                    else if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(middleName) || string.IsNullOrEmpty(middleName) && string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(firstName))
                    {
                        flag = true;
                        str1 = "A staff must have at least two names";
                    }
                    string str2 = "";
                    try
                    {
                        str2 = string.IsNullOrEmpty(strArray1[5].Trim()) ? "" : strArray1[5].Trim();
                    }
                    catch (Exception ex)
                    {
                    }
                    string lower = str2.ToLower();
                    int gender = 1;
                    if (lower == "male")
                        gender = 0;
                    else if (lower == "female")
                        gender = 1;
                    else if (lower == "intersex")
                    {
                        gender = 2;
                    }
                    else
                    {
                        flag = true;
                        str1 = "Please enter a valid gender. The only options are (male, female, intersex)";
                    }
                    string ethnicBackground = "";
                    try
                    {
                        ethnicBackground = string.IsNullOrEmpty(strArray1[6].Trim()) ? "" : strArray1[6].Trim();
                    }
                    catch (Exception ex)
                    {
                    }
                    string str3 = "";
                    try
                    {
                        str3 = string.IsNullOrEmpty(strArray1[7].Trim()) ? "" : strArray1[7].Trim();
                    }
                    catch (Exception ex)
                    {
                    }
                    DateTime dateOfBirth = new DateTime();
                    try
                    {
                        dateOfBirth = DateTime.FromOADate(Convert.ToDouble(str3));
                        if (dateOfBirth > DateTime.Now)
                        {
                            flag = true;
                            str1 = "Date of birth cannot be earlier than today";
                        }
                    }
                    catch (Exception ex)
                    {
                        flag = true;
                        str1 = "Please enter a valid value for date of birth";
                    }
                    string nationality = "";
                    try
                    {
                        nationality = string.IsNullOrEmpty(strArray1[8].Trim()) ? "" : strArray1[8].Trim();
                    }
                    catch (Exception ex)
                    {
                    }
                    string homeCounty = "";
                    try
                    {
                        homeCounty = string.IsNullOrEmpty(strArray1[9].Trim()) ? "" : strArray1[9].Trim();
                    }
                    catch (Exception ex)
                    {
                    }
                    string disabilityDescription = "";
                    try
                    {
                        disabilityDescription = string.IsNullOrEmpty(strArray1[10].Trim()) ? "" : strArray1[10].Trim();
                    }
                    catch (Exception ex)
                    {
                    }
                    string disabilityRegistrationCode = "";
                    try
                    {
                        disabilityRegistrationCode = string.IsNullOrEmpty(strArray1[11].Trim()) ? "" : strArray1[11].Trim();
                    }
                    catch (Exception ex)
                    {
                    }
                    string programDomain = "";
                    try
                    {
                        programDomain = string.IsNullOrEmpty(strArray1[12].Trim()) ? "" : strArray1[12].Trim();
                    }
                    catch (Exception ex)
                    {
                    }
                    string rankCode = "";
                    try
                    {
                        rankCode = string.IsNullOrEmpty(strArray1[13].Trim()) ? "" : strArray1[13].Trim();
                    }
                    catch (Exception ex)
                    {
                    }
                    string str4 = "";
                    try
                    {
                        str4 = string.IsNullOrEmpty(strArray1[14].Trim()) ? "" : strArray1[14].Trim();
                    }
                    catch (Exception ex)
                    {
                    }
                    DateTime dateOfFirstAppointment = new DateTime();
                    try
                    {
                        dateOfFirstAppointment = DateTime.FromOADate(Convert.ToDouble(str4));
                        if (dateOfFirstAppointment > DateTime.Now)
                        {
                            flag = true;
                            str1 = "Date of first appointment cannot be earlier than today";
                        }
                    }
                    catch (Exception ex)
                    {
                        flag = true;
                        str1 = "Please enter a valid value for date of first appointment";
                    }
                    string str5 = "";
                    try
                    {
                        str5 = string.IsNullOrEmpty(strArray1[15].Trim()) ? "" : strArray1[15].Trim();
                    }
                    catch (Exception ex)
                    {
                    }
                    int termsOfService = 0;
                    try
                    {
                        termsOfService = Convert.ToInt32(str5);
                        if (termsOfService > 2 || termsOfService < 1)
                            throw new Exception();
                        --termsOfService;
                    }
                    catch (Exception ex)
                    {
                        flag = true;
                        str1 = "Please enter a valid value for terms of service code. The only options are 1 for full time and 2 for part time ";
                    }
                    string str6 = "";
                    try
                    {
                        str6 = string.IsNullOrEmpty(strArray1[16].Trim()) ? "" : strArray1[16].Trim();
                    }
                    catch (Exception ex)
                    {
                    }
                    int highestAcademicQualification = 0;
                    try
                    {
                        highestAcademicQualification = Convert.ToInt32(str6);
                        if (highestAcademicQualification > 7 || highestAcademicQualification < 1)
                            throw new Exception();
                        --highestAcademicQualification;
                    }
                    catch (Exception ex)
                    {
                        flag = true;
                        str1 = "Please enter a valid value for highest academic qualification code. The options are between 1 and 7";
                    }
                    string campus = "";
                    try
                    {
                        campus = string.IsNullOrEmpty(strArray1[17].Trim()) ? "" : strArray1[17].Trim();
                    }
                    catch (Exception ex)
                    {
                    }
                    string userUserName = value.userUserName;
                    string userPassword = value.userPassword;
                    if (flag)
                    {
                        string[] strArray2 = new string[strArray1.Length + 1];
                        for (int index = 0; index < strArray1.Length; ++index)
                        {
                            strArray2[index] = strArray1[index];
                            if (index == 7 || index == 14)
                            {
                                try
                                {
                                    string str7 = DateTime.FromOADate(Convert.ToDouble(strArray1[index])).ToString("dd-MM-yy");
                                    strArray2[index] = str7;
                                }
                                catch (Exception ex)
                                {
                                    strArray2[index] = strArray1[index];
                                }
                            }
                        }
                        strArray2[strArray1.Length] = str1;
                        strArrayList.Add(strArray2);
                    }
                    else
                    {
                        string str7 = new Config().ObjNav().AddAcademicStaff(idNumber, payrollNo, firstName, middleName, lastName, gender, ethnicBackground, dateOfBirth, nationality, homeCounty, disabilityDescription, disabilityRegistrationCode, programDomain, rankCode, dateOfFirstAppointment, termsOfService, highestAcademicQualification, campus, userUserName, userPassword);
                        if (str7 != "success")
                        {
                            string[] strArray2 = new string[strArray1.Length + 1];
                            for (int index = 0; index < strArray1.Length; ++index)
                            {
                                strArray2[index] = strArray1[index];
                                if (index == 7 || index == 14)
                                {
                                    try
                                    {
                                        string str8 = DateTime.FromOADate(Convert.ToDouble(strArray1[index])).ToString("dd-MM-yy");
                                        strArray2[index] = str8;
                                    }
                                    catch (Exception ex)
                                    {
                                        strArray2[index] = strArray1[index];
                                    }
                                }
                            }
                            strArray2[strArray1.Length] = str7;
                            strArrayList.Add(strArray2);
                        }
                    }
                }
                catch (Exception ex1)
                {
                    string message = ex1.Message;
                    string[] strArray2 = new string[strArray1.Length + 1];
                    for (int index = 0; index < strArray1.Length; ++index)
                    {
                        strArray2[index] = strArray1[index];
                        if (index == 7 || index == 14)
                        {
                            try
                            {
                                string str = DateTime.FromOADate(Convert.ToDouble(strArray1[index])).ToString("dd-MM-yy");
                                strArray2[index] = str;
                            }
                            catch (Exception ex2)
                            {
                                strArray2[index] = strArray1[index];
                            }
                        }
                    }
                    strArray2[strArray1.Length] = message;
                    strArrayList.Add(strArray2);
                }
            }
            StudentJson studentJson = new StudentJson();
            studentJson.data = strArrayList;
            string columnMap = value.column_map;
            studentJson.column_map = columnMap;
            return studentJson;
        }

        [Route("addLibraryStaff")]
        public StudentJson AddLibraryStaff([FromBody] StudentJson value)
        {
            List<string[]> data = value.data;
            List<string[]> strArrayList = new List<string[]>();
            foreach (string[] strArray1 in data)
            {
                try
                {
                    string str1 = "";
                    bool flag = false;
                    string idNo = "";
                    string firstName = "";
                    string middleName = "";
                    string lastName = "";
                    string position = "";
                    string str2 = "";
                    string campusCode = "";
                    try
                    {
                        idNo = string.IsNullOrEmpty(strArray1[0].Trim()) ? "" : strArray1[0].Trim();
                    }
                    catch (Exception ex)
                    {
                    }
                    try
                    {
                        firstName = string.IsNullOrEmpty(strArray1[1].Trim()) ? "" : strArray1[1].Trim();
                    }
                    catch (Exception ex)
                    {
                    }
                    try
                    {
                        middleName = string.IsNullOrEmpty(strArray1[2].Trim()) ? "" : strArray1[2].Trim();
                    }
                    catch (Exception ex)
                    {
                    }
                    try
                    {
                        lastName = string.IsNullOrEmpty(strArray1[3].Trim()) ? "" : strArray1[3].Trim();
                    }
                    catch (Exception ex)
                    {
                    }
                    try
                    {
                        position = string.IsNullOrEmpty(strArray1[5].Trim()) ? "" : strArray1[5].Trim();
                    }
                    catch (Exception ex)
                    {
                    }
                    try
                    {
                        str2 = string.IsNullOrEmpty(strArray1[6].Trim()) ? "" : strArray1[6].Trim();
                    }
                    catch (Exception ex)
                    {
                    }
                    try
                    {
                        campusCode = string.IsNullOrEmpty(strArray1[7].Trim()) ? "" : strArray1[7].Trim();
                    }
                    catch (Exception ex)
                    {
                    }
                    if (string.IsNullOrEmpty(idNo))
                    {
                        flag = true;
                        str1 = "ID No/Passport No is mandatory";
                    }
                    else if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(middleName) || string.IsNullOrEmpty(middleName) && string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(firstName))
                    {
                        flag = true;
                        str1 = "A staff must have at least two names";
                    }
                    string str3 = "";
                    try
                    {
                        str3 = string.IsNullOrEmpty(strArray1[4].Trim()) ? "" : strArray1[4].Trim();
                    }
                    catch (Exception ex)
                    {
                    }
                    DateTime dob = new DateTime();
                    try
                    {
                        dob = DateTime.FromOADate(Convert.ToDouble(str3));
                        if (dob > DateTime.Now)
                        {
                            flag = true;
                            str1 = "Date of birth cannot be earlier than today";
                        }
                    }
                    catch (Exception ex)
                    {
                        flag = true;
                        str1 = "Please enter a valid value for date of birth";
                    }
                    int highestAcademicQualification = 0;
                    try
                    {
                        highestAcademicQualification = Convert.ToInt32(str2);
                        if (highestAcademicQualification > 7 || highestAcademicQualification < 1)
                            throw new Exception();
                        --highestAcademicQualification;
                    }
                    catch (Exception ex)
                    {
                        flag = true;
                        str1 = "Please enter a valid value for highest academic qualification code. The options are between 1 and 7";
                    }
                    string userUserName = value.userUserName;
                    string userPassword = value.userPassword;
                    if (flag)
                    {
                        string[] strArray2 = new string[strArray1.Length + 1];
                        for (int index = 0; index < strArray1.Length; ++index)
                        {
                            strArray2[index] = strArray1[index];
                            if (index == 4)
                            {
                                try
                                {
                                    string str4 = DateTime.FromOADate(Convert.ToDouble(strArray1[index])).ToString("dd-MM-yy");
                                    strArray2[index] = str4;
                                }
                                catch (Exception ex)
                                {
                                    strArray2[index] = strArray1[index];
                                }
                            }
                        }
                        strArray2[strArray1.Length] = str1;
                        strArrayList.Add(strArray2);
                    }
                    else
                    {
                        string str4 = new Config().ObjNav().AddLibraryStaff(userUserName, userPassword, idNo, firstName, middleName, lastName, dob, position, highestAcademicQualification, campusCode);
                        if (str4 != "success")
                        {
                            string[] strArray2 = new string[strArray1.Length + 1];
                            for (int index = 0; index < strArray1.Length; ++index)
                            {
                                strArray2[index] = strArray1[index];
                                if (index == 7 || index == 14)
                                {
                                    try
                                    {
                                        string str5 = DateTime.FromOADate(Convert.ToDouble(strArray1[index])).ToString("dd-MM-yy");
                                        strArray2[index] = str5;
                                    }
                                    catch (Exception ex)
                                    {
                                        strArray2[index] = strArray1[index];
                                    }
                                }
                            }
                            strArray2[strArray1.Length] = str4;
                            strArrayList.Add(strArray2);
                        }
                    }
                }
                catch (Exception ex1)
                {
                    string message = ex1.Message;
                    string[] strArray2 = new string[strArray1.Length + 1];
                    for (int index = 0; index < strArray1.Length; ++index)
                    {
                        strArray2[index] = strArray1[index];
                        if (index == 4)
                        {
                            try
                            {
                                string str = DateTime.FromOADate(Convert.ToDouble(strArray1[index])).ToString("dd-MM-yy");
                                strArray2[index] = str;
                            }
                            catch (Exception ex2)
                            {
                                strArray2[index] = strArray1[index];
                            }
                        }
                    }
                    strArray2[strArray1.Length] = message;
                    strArrayList.Add(strArray2);
                }
            }
            StudentJson studentJson = new StudentJson();
            studentJson.data = strArrayList;
            string columnMap = value.column_map;
            studentJson.column_map = columnMap;
            return studentJson;
        }

        //[Route("addNonAcademicStaff")]
        //public StudentJson AddNonAcademicStaff([FromBody] StudentJson value)
        //{
        //    List<string[]> data = value.data;
        //    List<string[]> strArrayList = new List<string[]>();
        //    foreach (string[] strArray in data)
        //    {
        //        try
        //        {
        //            if (!new Config().ObjNav().AddNonAcademicStaff(strArray[0], strArray[1], strArray[2], strArray[3], strArray[4], strArray[5], DateTime.FromOADate(Convert.ToDouble(strArray[6])), strArray[7], strArray[8], strArray[9], strArray[10], "", ""))
        //                strArrayList.Add(strArray);
        //        }
        //        finally
        //        {
        //        }
        //    }
        //    return new StudentJson() { column_map = "", data = strArrayList };
        //}

        //[Route("addCase")]
        //public StudentJson AddCase([FromBody] StudentJson value)
        //{
        //    List<string[]> data = value.data;
        //    List<string[]> strArrayList = new List<string[]>();
        //    foreach (string[] strArray in data)
        //    {
        //        try
        //        {
        //            if (!new Config().ObjNav().AddDisciplineCase(strArray[0], strArray[1], DateTime.FromOADate(Convert.ToDouble(strArray[2])), strArray[3], DateTime.FromOADate(Convert.ToDouble(strArray[4])), "", ""))
        //                strArrayList.Add(strArray);
        //        }
        //        finally
        //        {
        //        }
        //    }
        //    return new StudentJson() { column_map = "", data = strArrayList };
        //}

        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //public void Delete(int id)
        //{
        //}
    }
}

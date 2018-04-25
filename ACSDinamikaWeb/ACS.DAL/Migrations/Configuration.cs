namespace ACS.DAL.Migrations
{
    using EF;
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using XMLData;

    internal sealed class Configuration : DbMigrationsConfiguration<ACSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ACSContext db)
        {
            Console.WriteLine("GenerateUserRepository");
            GenerateUserRepository(db);
            Console.WriteLine("GenerateDepartmentRepository");
            GenerateDepartmentRepository(db);
            Console.WriteLine("GeneratePostRepository");
            GeneratePostRepository(db);
            Console.WriteLine("GeneratePostUser�ode1�Repository");
            GeneratePostUser�ode1�Repository(db);
            Console.WriteLine("GenerateWorkHistoryRepository");
            GenerateWorkHistoryRepository(db);
            Console.WriteLine("GenerateTypeAccessRepository");
            GenerateTypeAccessRepository(db);
            Console.WriteLine("GenerateTypeRecordChancelleryRepository");
            GenerateTypeRecordChancelleryRepository(db);
        }

        /// <summary>
        /// ���������� ���� ������ �������������
        /// </summary>
        static void GenerateUserRepository(ACSContext Context)
        {
            // var location = System.Reflection.Assembly.GetExecutingAssembly().Location;

            //������������� �� ������������
            //������������ �� ����������
            //������� �� ������ ������ ������ � ����� ����� ����� ��������
            //�.� ��� ����� ������ ���������� ������ � �������
            //������������� �� ���� �������� � �������
            var query = from db in DataLoader1C.Data.����������
                        where db.������������ == "��"
                        group db by db.���������� into @group
                        from dataEmpl in @group
                        where XMLDataTypeConverter.GetDateTime(dataEmpl.������)
                        == @group.Max(dataEmpl => XMLDataTypeConverter.GetDateTime(dataEmpl.������))
                        orderby XMLDataTypeConverter.GetDateTime(dataEmpl.������), dataEmpl.���
                        select dataEmpl;


            foreach (var dataUser in query)
            {
                string[] DataFullNameEmp = dataUser.���.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                DataUserInActiveDirectory dataUserAD = new DataUserInActiveDirectory();

                dataUserAD.SearchData(DataFullNameEmp[0], DataFullNameEmp[1]);

                Console.WriteLine(dataUserAD.SID.ToString().Length.ToString());
                var newDataUser = new User()
                {
                    
                    LName = DataFullNameEmp[0],
                    FName = DataFullNameEmp[1],
                    MName = DataFullNameEmp[2],
                    //FullName = dataUser.���,
                    //ShortName = String.Format("{0} {1}.{2}.", DataFullNameEmp[0], DataFullNameEmp[1].FirstOrDefault(), DataFullNameEmp[2].FirstOrDefault()),
                    SID = dataUserAD.SID,
                    Guid1C = Guid.Parse(dataUser.����������),

                    Birthday = XMLDataTypeConverter.GetDateTime(dataUser.������������),
                    //EMail = dataUserAD.Email,
                    //PersonnelNumber = Convert.ToInt32(dataUser.��������������),
                    PersonnelNumber = dataUser.��������������,

                    Passport = new UserPassport()
                    {
                        //���������� ������
                        DateOfIssue = XMLDataTypeConverter.GetDateTime(dataUser.������������������),
                        IssuedBy = dataUser.����������������,
                        Number = dataUser.�������������.ToString(),
                        Series = dataUser.�������������,
                        UnitCode = dataUser.������������������������,
                    },

                    //s_AuthorID = 1,
                    //s_EditorID = 1,
                };

                //if (newDataUser.Passport == null)
                //{
                //    newDataUser.Passport = new UserPassport()
                //    {
                //        //���������� ������
                //        DateOfIssue = XMLDataTypeConverter.GetDateTime(dataUser.������������������),
                //        IssuedBy = dataUser.����������������,
                //        Number = dataUser.�������������.ToString(),
                //        Series = dataUser.�������������,
                //        UnitCode = dataUser.������������������������,
                //    };
                //}
                //else
                //{
                //    //���������� ������
                //    newDataUser.Passport.DateOfIssue = XMLDataTypeConverter.GetDateTime(dataUser.������������������);
                //    newDataUser.Passport.IssuedBy = dataUser.����������������;
                //    newDataUser.Passport.Number = dataUser.�������������.ToString();
                //    newDataUser.Passport.Series = dataUser.�������������;
                //    newDataUser.Passport.UnitCode = dataUser.������������������������;
                //}

                Context.Users.Add(newDataUser);

                Context.SaveChanges();
            }

        }

        /// <summary>
        /// ���������� ���� ������ �������
        /// </summary>
        static void GenerateDepartmentRepository(ACSContext Context)
        {
            // var location = System.Reflection.Assembly.GetExecutingAssembly().Location;

            //���������� ������� �� ���� �����������
            var query = from dataDeport in DataLoader1C.Data.������������������������
                        orderby dataDeport.���
                        select dataDeport;

            foreach (var dataDepartment in query)
            {
                var department = new Department()
                {
                    Name = dataDepartment.������������,
                    Code1C = int.Parse(dataDepartment.���),
                    IsDeleted = XMLDataTypeConverter.ToBoolean(dataDepartment.���������������),
                    Inactive = XMLDataTypeConverter.ToBoolean(dataDepartment.����������),
                    s_AuthorID = 1,
                    s_EditorID = 1,
                };

                Context.Departments.Add(department);
                Context.SaveChanges();
            }
        }

        /// <summary>
        /// ���������� �� ������� ����������
        /// </summary>
        public static void GeneratePostRepository(ACSContext Context)
        {

            //��� ���������
            var query = (from dataUser in DataLoader1C.Data.����������
                         from PostHistory in dataUser.���������������
                         select PostHistory.���������).Distinct();

            foreach (var namePost in query)
            {
                var post = new PostNameUser()
                {
                    Name = namePost,
                    s_AuthorID = 1,
                    s_EditorID = 1,
                };

                Context.PostUsers.Add(post);
                Context.SaveChanges();
            }
        }

        /// <summary>
        /// ��������� ��� ������� ���������� ���� ��������� 1�
        /// </summary>
        /// <param name="codePost1C"></param>
        /// <returns></returns>
        static Guid? GetGuid1CUser(string codePost1C)
        {
            var result = (from dUser in DataLoader1C.Data.����������
                          where dUser.��� == codePost1C
                          select dUser.����������).Distinct().First();
            return Guid.Parse(result);
        }

        /// <summary>
        /// ���������� �� ��� ��������� 1� � ���� ���� ��� �����������
        /// </summary>
        static void GeneratePostUser�ode1�Repository(ACSContext Context)
        {
            //��� ���������
            //var query = (from dUser in DataLoader1C.Data.����������
            //             select dUser.���).Distinct();

            var query = from db in DataLoader1C.Data.����������
                        where db.������������ == "��"
                        group db by db.��� into @group
                        from dataEmpl in @group
                        where XMLDataTypeConverter.GetDateTime(dataEmpl.������)
                        == @group.Max(dataEmpl => XMLDataTypeConverter.GetDateTime(dataEmpl.������))
                        orderby XMLDataTypeConverter.GetDateTime(dataEmpl.������), dataEmpl.���
                        select dataEmpl;

            foreach (var empl in query)
            {
                Guid Guid1C;

                if (!Guid.TryParse(empl.����������, out Guid1C)) continue;

                User userWithGuid1C = Context.Users.First(u => u.Guid1C == Guid1C);

                if (userWithGuid1C == null) continue;

                int? Id = userWithGuid1C.Id;

                var postUser�ode1� = new PostUser�ode1�()
                {
                    CodePost1C = Guid.Parse(empl.���),

                    User = userWithGuid1C,
                    s_AuthorID = 1,
                    s_EditorID = 1
                };

                Context.PostUser�ode1�.Add(postUser�ode1�);
                Context.SaveChanges();
            }
        }

        static DateTime? GetEndDateWorkHistory(������������������� dUser, ���������������������������������������� wh)
        {
            var WHlist = dUser.���������������.ToList();

            if (WHlist == null) return null;

            int indexLastElement = WHlist.Count - 1;

            int indexWH = dUser.���������������.ToList().IndexOf(wh);

            if (indexLastElement == indexWH)
                return null;

            return XMLDataTypeConverter.GetDateTime(WHlist.ElementAt(indexWH + 1).����);
        }


        static void GenerateWorkHistoryRepository(ACSContext Context)
        {
            //��� ���������
            var query = (from dUser in DataLoader1C.Data.����������
                         from wh in dUser.���������������
                         orderby wh.����
                         select new
                         {
                             ���������������� = wh.����������������,
                             ��������� = wh.���������,
                             ���������� = dUser.����������,
                             ��� = Guid.Parse(dUser.���),
                             ���������� = wh.����,
                             ������������� = GetEndDateWorkHistory(dUser, wh),
                             ������ = wh.������
                         });

            foreach (var WorkHistory in query)
            {

                Department department = Context.Departments.First(d => d.Code1C == WorkHistory.����������������);
                if (department == null) continue;

                //������������1�
                PostUser�ode1� PUC = Context.PostUser�ode1�.First
                    (puc => puc.CodePost1C == WorkHistory.���);

                if (PUC == null) continue;

                var wh = new WorkHistory()
                {

                    Department = department,
                    PostName = WorkHistory.���������,
                    StartDate = XMLDataTypeConverter.GetDateTime(WorkHistory.����������),
                    EndDate = WorkHistory.�������������,
                    Rate = double.Parse(WorkHistory.������),

                    PostUser�ode1� = PUC,
                    s_AuthorID = 1,
                    s_EditorID = 1
                };

                //Context.PostUser�ode1�.Add(postUser�ode1�);
                Context.SaveChanges();
            }
        }
        static void GenerateTypeAccessRepository(ACSContext Context)
        {

            var tA1 = new TypeAccess()
            {
                Name = "��������",
                s_AuthorID = 1,
                s_EditorID = 1,
            };
            var tA2 = new TypeAccess()
            {
                Name = "��������������",
                s_AuthorID = 1,
                s_EditorID = 1,
            };
            var tA3 = new TypeAccess()
            {
                Name = "��������",
                s_AuthorID = 1,
                s_EditorID = 1,
            };

            Context.TypeAccesses.AddRange(new List<TypeAccess>() { tA1, tA2, tA3 });
            Context.SaveChanges();

        }
        static void GenerateTypeRecordChancelleryRepository(ACSContext Context)
        {

            var tRC1 = new TypeRecordChancellery()
            {
                Name = "��������",
                s_AuthorID = 1,
                s_EditorID = 1,
            };
            var tRC2 = new TypeRecordChancellery()
            {
                Name = "���������",
                s_AuthorID = 1,
                s_EditorID = 1,
            };
            var tRC3 = new TypeRecordChancellery()
            {
                Name = "���������",
                s_AuthorID = 1,
                s_EditorID = 1,
            };

            Context.TypeRecordChancelleries.AddRange(new List<TypeRecordChancellery>() { tRC1, tRC2, tRC3 });
            Context.SaveChanges();

        }
    }




}

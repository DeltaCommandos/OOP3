using Npgsql;
using System;
using OOP3;



    internal class Program
    {
        //Process Yo = new Process();
        private static string connect = " Server = localhost;Port = 5432;Database = MangO; User Id = postgres; Password = GOOOOOOOOOOOOOOOOOOOL";
        private static NpgsqlCommand cmd;
        private static NpgsqlDataReader reader;


        static void Main(string[] args)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connect);
            connection.Open();
            cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("   ____               _____ _                 _____  ____  \r\n  / __ \\             |  __ (_)               |  __ \\|  _ \\ \r\n | |  | |_ __   ___  | |__) |  ___  ___ ___  | |  | | |_) |\r\n | |  | | '_ \\ / _ \\ |  ___/ |/ _ \\/ __/ _ \\ | |  | |  _ < \r\n | |__| | | | |  __/ | |   | |  __/ (_|  __/_| |__| | |_) |\r\n  \\____/|_| |_|\\___| |_|   |_|\\___|\\___\\___(_)_____/|____/ \r\n                                                           ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Выберите действие");
                Console.WriteLine("-----------------");

                Console.WriteLine("----1. Создать бд");
                Console.WriteLine("----2. Вывести бд");
                Console.WriteLine("----3. Изменить бд");
                Console.WriteLine("----4. Удалить бд");
                Console.WriteLine("----5. Выход");
                Console.WriteLine("-----------------");

                int input = 0;
                if (int.TryParse(Console.ReadLine(), out input) && input >= 1 && input <= 5)
                {
                    switch (input)
                    {
                        case 1:
                            Adder();
                            Console.WriteLine("Нажмите любую кнопку чтобы продолжить");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 2:
                            Printer();
                            Console.WriteLine("Нажмите любую кнопку чтобы продолжить");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 3:
                            Updater();
                            Console.WriteLine("Нажмите любую кнопку чтобы продолжить");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case 4:
                            Deleter();
                            Console.WriteLine("Нажмите любую кнопку чтобы продолжить");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }

            connection.Close();

        }



        private static bool CharExists(int id)
        {
            cmd.CommandText = $"select * from \"Characters\" where id = {id}";
            reader = cmd.ExecuteReader();
            bool res = reader.HasRows;
            cmd.Dispose();
            reader.Close();
            return res;
        }
        private static bool AgeExists(int id)
        {
            cmd.CommandText = $"select * from \"Characters\" where \"Characters\".age = {id}";
            reader = cmd.ExecuteReader();
            bool res = reader.HasRows;
            cmd.Dispose();
            reader.Close();
            return res;
        }
        private static bool OrgExists(int id)
        {
            cmd.CommandText = $"select * from \"Organisation\" where id = {id}";
            reader = cmd.ExecuteReader();
            bool res = reader.HasRows;
            cmd.Dispose();
            reader.Close();
            return res;
        }
        private static bool DFExists(int id)
        {
            cmd.CommandText = $"select * from \"Devil_Fruits\" where id = {id}";
            reader = cmd.ExecuteReader();
            bool res = reader.HasRows;
            cmd.Dispose();
            reader.Close();
            return res;
        }



        private static bool CharacterDependet(int id)
        {
            cmd.CommandText = $"select * from \"Characters\" where org_id = {id}";
            reader = cmd.ExecuteReader();
            bool res = reader.HasRows;
            cmd.Dispose();
            reader.Close();
            return res;
        }
        private static bool DFDependet(int id)
        {
            cmd.CommandText = $"select * from \"Organisation\" where devil_id = {id}";
            reader = cmd.ExecuteReader();
            bool res = reader.HasRows;
            cmd.Dispose();
            reader.Close();
            return res;
        }




        public static void Adder()
        {
            Console.WriteLine("Что вы хотите добавить?");
            Console.WriteLine("\t1. добавить персонажа");
            Console.WriteLine("\t2. добавить организацию");
            Console.WriteLine("\t3. добавить дьявольский фрукт");
            int input = 0;
            if (int.TryParse(Console.ReadLine(), out input) && input >= 1 && input <= 3)
            {
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Введите имя");
                        string chname = Console.ReadLine();
                        Console.WriteLine("Введите возраст");
                        string chage = Console.ReadLine();

                        Console.WriteLine("Введите id организации");
                        cmd.CommandText = "select * from \"Organisation\"";

                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Console.Write(reader.GetInt32(0));
                                Console.Write(" - ");
                                Console.WriteLine(reader.GetString(1));
                            }
                        }
                        cmd.Dispose();
                        reader.Close();
                        int orgid = 0;
                        if (int.TryParse(Console.ReadLine(), out orgid))
                        {
                            if (OrgExists(orgid))
                            {
                                reader = cmd.ExecuteReader();
                                if (reader.HasRows)
                                {
                                    cmd.Dispose();
                                    reader.Close();
                                    cmd.CommandText = $"insert into \"Characters\"(name,age,org_id) values('{chname}',{chage},{orgid})";
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Нет такого id");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод!");
                        }
                        break;
                    case 2:
                        //reader = cmd.ExecuteReader();
                        //if (reader.HasRows)
                        //{
                        //    cmd.Dispose();
                        //    reader.Close();
                        //    cmd.CommandText = $"insert into \"Organisation\"(name,kol_members) values('{orgname}',{kol_members})";
                        //    cmd.ExecuteNonQuery();
                        //}

                        Console.WriteLine("Введите название");
                        string orgname = Console.ReadLine();
                        Console.WriteLine("Введите количество участников");
                        string kol_members = Console.ReadLine();
                        cmd.CommandText = $"insert into \"Organisation\"(name,kol_members) values('{orgname}',{kol_members})";
                        cmd.ExecuteNonQuery();
                        break;
                        //}
                        //else
                        //{
                        //    Console.WriteLine("Нет такого id");
                        //}
                        //}
                        //else
                        //{
                        //    Console.WriteLine("Некорректный ввод!");
                        //}

                        break;
                    case 3:

                        Console.WriteLine("Введите имя дьявольского фрукта");
                        string authorname = Console.ReadLine();
                        cmd.CommandText = $"insert into\"Devil_Fruits\"(name) values('{authorname}')";
                        cmd.ExecuteNonQuery();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Неправильный Ввод");
            }

        }
        public static void Printer()
        {
            Console.WriteLine("Выберите таблицу");
            Console.WriteLine("\t1. Персонажи");
            Console.WriteLine("\t2. Организации");
            Console.WriteLine("\t3. Дьявольские фрукты");
            int input = 0;
            if (int.TryParse(Console.ReadLine(), out input) && input >= 1 && input <= 3)
            {
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Что вы хотите вывести?");
                        Console.WriteLine("\t1. Всю таблицу");
                        Console.WriteLine("\t2. по id персонажа");
                        Console.WriteLine("\t3. членов определенной организации");
                        Console.WriteLine("\t4. персонажей определенного возраста");
                        int input1 = 0;
                        if (int.TryParse(Console.ReadLine(), out input1) && input1 >= 1 && input1 <= 4)
                        {
                            switch (input1)
                            {
                                case 1://all

                                    cmd.CommandText = $"select \"Characters\".id, \"Characters\".name, \"Characters\".age, \"Organisation\".name from \"Characters\"\r\ninner join \"Organisation\" on \"Characters\".org_id = \"Organisation\".id order by \"Characters\".id ";
                                    reader = cmd.ExecuteReader();
                                    while (reader.Read())
                                    {
                                        Console.WriteLine("Айди - {0} Имя - {1} Возраст - {2} Организация - {3} Дьявольский фрукт - {4}", reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4));
                                    }
                                    cmd.Dispose();
                                    reader.Close();
                                    break;
                                case 2://id
                                    Console.WriteLine("Введите id: ");
                                    int cid = 0;
                                    if (int.TryParse(Console.ReadLine(), out cid))
                                    {
                                        if (CharExists(cid))
                                        {
                                            cmd.CommandText = $"select \"Characters\".id, \"Characters\".name, \"Characters\".age, \"Organisation\".name from \"Characters\"\r\ninner join \"Organisation\" on \"Characters\".org_id = \"Organisation\".id where \"Characters\".id = {cid} ";
                                            reader = cmd.ExecuteReader();
                                            while (reader.Read())
                                            {
                                                Console.WriteLine("Айди - {0} Имя - {1} Возраст - {2} Из какой организации - {3}", reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3));
                                            }
                                            cmd.Dispose();
                                            reader.Close();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Нет персонажа с таким id");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Некорректный ввод");
                                    }
                                    break;

                                case 3://org
                                    Console.WriteLine("Введите id организации: ");
                                    cmd.CommandText = "select * from \"Organisation\"";
                                    reader = cmd.ExecuteReader();
                                    if (reader.HasRows)
                                    {
                                        while (reader.Read())
                                        {
                                            Console.Write(reader.GetInt32(0));
                                            Console.Write(" - ");
                                            Console.WriteLine(reader.GetString(1));
                                        }

                                    }
                                    cmd.Dispose();
                                    reader.Close();
                                    int mid = 0;
                                    if (int.TryParse(Console.ReadLine(), out mid))
                                    {
                                        if (OrgExists(mid))
                                        {
                                            cmd.CommandText = $"select \"Characters\".id, \"Characters\".name, \"Characters\".age, \"Organisation\".name from \"Characters\"\r\ninner join \"Organisation\" on \"Characters\".org_id = \"Organisation\".id where \"Characters\".org_id = {mid} order by \"Characters\".id ";
                                            reader = cmd.ExecuteReader();
                                            while (reader.Read())
                                            {
                                                Console.WriteLine("Айди - {0} Имя - {1} Возраст - {2} Из какой организации - {3}", reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3));
                                            }
                                            cmd.Dispose();
                                            reader.Close();
                                        }
                                        else
                                        {

                                            Console.WriteLine("Нет организации с таким id");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Некорректный ввод");
                                    }
                                    break;
                                case 4://age
                                    Console.WriteLine("Введите возраст: ");
                                    int agid = 0;
                                    if (int.TryParse(Console.ReadLine(), out agid))
                                    {
                                        if (AgeExists(agid))
                                        {
                                            cmd.CommandText = $"select \"Characters\".id, \"Characters\".name, \"Characters\".age, \"Organisation\".name from \"Characters\"\r\ninner join \"Organisation\" on \"Characters\".org_id = \"Organisation\".id where \"Characters\".age = {agid} order by \"Characters\".id";
                                            reader = cmd.ExecuteReader();
                                            while (reader.Read())
                                            {
                                                Console.WriteLine("Айди - {0} Имя - {1} Возраст - {2} Из какой организации - {3}", reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3));
                                            }
                                            cmd.Dispose();
                                            reader.Close();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Нет персонажа с таким возрастом");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Некорректный ввод");
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Что вы хотите вывести?");
                        Console.WriteLine("\t1. Всю таблицу");
                        Console.WriteLine("\t2. по id организации");
                        //Console.WriteLine("\t3. по количеству членов организации");
                        int input2 = 0;
                        if (int.TryParse(Console.ReadLine(), out input2) && input2 >= 1 && input2 <= 3)
                        {
                            switch (input2)
                            {
                                case 1://all
                                    cmd.CommandText = $"select  \"Organisation\".id, \"Organisation\".name, \"Organisation\".kol_members from \"Organisation\"";
                                    reader = cmd.ExecuteReader();
                                    while (reader.Read())
                                    {
                                        Console.WriteLine("Айди - {0} Название - {1} Количество глав - {2}", reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                                    }
                                    cmd.Dispose();
                                    reader.Close();
                                    break;
                                case 2://id
                                    Console.WriteLine("Введите id: ");
                                    int mmid = 0;
                                    if (int.TryParse(Console.ReadLine(), out mmid))
                                    {
                                        if (OrgExists(mmid))
                                        {
                                            cmd.CommandText = $"select \"Organisation\".id, \"Organisation\".name, \"Organisation\".kol_members from \"Organisation\" where \"Organisation\".id = {mmid}";
                                            reader = cmd.ExecuteReader();
                                            while (reader.Read())
                                            {
                                                Console.WriteLine("Айди - {0} Название - {1} Количество членов организации - {2}", reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                                            }
                                            cmd.Dispose();
                                            reader.Close();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Нет Персонажа с таким id");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Некорректный ввод");
                                    }
                                    break;
                                    //case 3://kol
                                    //    Console.WriteLine("Введите id дьявольского фрукта: ");
                                    //    cmd.CommandText = "select * from \"Devil_Fruits\"";
                                    //    reader = cmd.ExecuteReader();
                                    //    if (reader.HasRows)
                                    //    {
                                    //        while (reader.Read())
                                    //        {
                                    //            Console.Write(reader.GetInt32(0));
                                    //            Console.Write(" - ");
                                    //            Console.WriteLine(reader.GetString(1));
                                    //        }

                                    //    }
                                    //    cmd.Dispose();
                                    //    reader.Close();
                                    //    int aaid = 0;
                                    //    if (int.TryParse(Console.ReadLine(), out aaid))
                                    //    {
                                    //        if (DFExists(aaid))
                                    //        {
                                    //            cmd.CommandText = $"select \"Organisation\".id, \"Organisation\".name, \"Organisation\".kol_members, \"Devil_Fruits\".name from \"Organisation\"\r\ninner join \"Devil_Fruits\" on \"Organisation\".devil_id = \"Devil_Fruits\".id where \"Organisation\".devil_id = {aaid} order by \"Organisation\".id";
                                    //            reader = cmd.ExecuteReader();
                                    //            while (reader.Read())
                                    //            {
                                    //                Console.WriteLine("Айди - {0} Название - {1} Количество глав - {2} Автор - {3}", reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3));
                                    //            }
                                    //            cmd.Dispose();
                                    //            reader.Close();
                                    //        }
                                    //        else
                                    //        {
                                    //            Console.WriteLine("Нет дьявольский фрукт с таким id");
                                    //        }
                                    //    }
                                    //    else
                                    //    {
                                    //        Console.WriteLine("Некорректный ввод");
                                    //    }
                                    //    break;

                            }

                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Что вы хотите вывести?");
                        Console.WriteLine("\t1. Всю таблицу");
                        Console.WriteLine("\t2. по названию дьявольского фрукта");
                        int input3 = 0;
                        if (int.TryParse(Console.ReadLine(), out input2) && input2 >= 1 && input2 <= 2)
                        {
                            switch (input2)
                            {
                                case 1:
                                    cmd.CommandText = "select * from \"Devil_Fruits\" order by id";
                                    reader = cmd.ExecuteReader();
                                    while (reader.Read())
                                    {
                                        Console.WriteLine("Айди - {0}, Название - {1}", reader.GetInt32(0), reader.GetString(1));
                                    }
                                    cmd.Dispose();
                                    reader.Close();
                                    break;
                                case 2:
                                    Console.WriteLine("Введите название дьявольского фрукта: ");
                                    //cmd.CommandText = "select * from \"Devil_Fruits\" order by id";
                                    //reader = cmd.ExecuteReader();
                                    //if (reader.HasRows)
                                    //{
                                    //    while (reader.Read())
                                    //    {
                                    //        Console.Write(reader.GetInt32(0));
                                    //        Console.Write(" - ");
                                    //        Console.WriteLine(reader.GetString(1));
                                    //    }

                                    //}
                                    //cmd.Dispose();
                                    //reader.Close();
                                    int dfname = 0;
                                    if (int.TryParse(Console.ReadLine(), out dfname))
                                    {
                                        if (DFExists(dfname))
                                        {
                                            cmd.CommandText = $"select * from \"Devil_Fruits\" where name = {dfname}";
                                            reader = cmd.ExecuteReader();
                                            while (reader.Read())
                                            {
                                                Console.WriteLine("Айди - {0}, Имя - {1}", reader.GetInt32(0), reader.GetString(1));
                                            }
                                            cmd.Dispose();
                                            reader.Close();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Нет дьявольского фрукта с таким названием");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Некорректный ввод");
                                    }
                                    break;
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод");
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод");
            }
        }
        public static void Updater()
        {
            Console.WriteLine("Выберите таблицу");
            Console.WriteLine("\t1. Персонажи");
            Console.WriteLine("\t2. Организации");
            Console.WriteLine("\t3. Дьявольские фрукты");
            int input1 = 0;
            if (int.TryParse(Console.ReadLine(), out input1) && input1 >= 1 && input1 <= 3)
            {
                switch (input1)
                {
                    case 1:
                        int str_ID = 0;
                        Console.WriteLine("Введите id строки которую хотите изменить");
                        if (int.TryParse(Console.ReadLine(), out str_ID))
                        {
                            if (CharExists(str_ID))
                            {
                                Console.WriteLine("Что вы хотите изменить?");
                                Console.WriteLine("\t1. Имя");
                                Console.WriteLine("\t2. Возраст");
                                Console.WriteLine("\t3. id организации");
                                Console.WriteLine("\t4. id фрукта");

                                int xddid = 0;
                                if (int.TryParse(Console.ReadLine(), out xddid) && xddid >= 1 && xddid <= 3)
                                {
                                    switch (xddid)
                                    {
                                        case 1:
                                            Console.WriteLine("Введите новое имя");
                                            string tempname = Console.ReadLine();
                                            cmd.CommandText = $"update \"Characters\" set name = '{tempname}' where \"Characters\".id = {str_ID}";
                                            cmd.ExecuteNonQuery();
                                            break;
                                        case 2:
                                            Console.WriteLine("Введите новый возраст");
                                            int tempage = 0;
                                            if (int.TryParse(Console.ReadLine(), out tempage))
                                            {
                                                cmd.CommandText = $"update \"Characters\" set age = {tempage} where \"Characters\".id = {str_ID}";
                                                cmd.ExecuteNonQuery();
                                            }
                                            else
                                            {
                                                Console.WriteLine("Некоректный Ввод");
                                            }
                                            break;
                                        case 3:
                                            Console.WriteLine("Введите новый id организации");
                                            int tempseriesid = 0;
                                            if (int.TryParse(Console.ReadLine(), out tempseriesid))
                                            {
                                                if (OrgExists(tempseriesid))
                                                {
                                                    cmd.CommandText = $"update \"Characters\" set org_id = {tempseriesid} where id = {str_ID}";
                                                    cmd.ExecuteNonQuery();
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Манги с таким id, не существует");
                                                }
                                            }
                                            break;
                                        case 4:
                                            Console.WriteLine();
                                            Console.WriteLine("Введите новый id фрукта");
                                            int temp_df_id = 0;
                                            if (int.TryParse(Console.ReadLine(), out temp_df_id))
                                            {
                                                if (DFExists(temp_df_id))
                                                {
                                                    cmd.CommandText = $"update \"Characters\" set devil_id = {temp_df_id} where id = {str_ID}";
                                                    cmd.ExecuteNonQuery();
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Фрукта с таким id, не существует");
                                                }
                                            }

                                            break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Некорректный ввод");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Нет персонажа с таким id");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод");
                        }
                        break;
                    case 2:
                        int str_ID2 = 0;
                        Console.WriteLine("Введите id строки которую хотите изменить");
                        if (int.TryParse(Console.ReadLine(), out str_ID2))
                        {
                            if (OrgExists(str_ID2))
                            {
                                Console.WriteLine("Что вы хотите изменить?");
                                Console.WriteLine("\t1. Названия");
                                Console.WriteLine("\t2. К-во членов");
                                int lolid = 0;
                                if (int.TryParse(Console.ReadLine(), out lolid) && lolid >= 1 && lolid <= 3)
                                {
                                    switch (lolid)
                                    {
                                        case 1:
                                            Console.WriteLine("Введите новое Название");
                                            string temporgname = Console.ReadLine();
                                            cmd.CommandText = $"update \"Organisation\" set name = '{temporgname}' where \"Organisation\".id = {str_ID2}";
                                            cmd.ExecuteNonQuery();
                                            break;
                                        case 2:
                                            Console.WriteLine("Введите новое количество членов");
                                            int tempmembers = 0;
                                            if (int.TryParse(Console.ReadLine(), out tempmembers))
                                            {
                                                cmd.CommandText = $"update \"Organisation\" set kol_members = '{tempmembers}' where \"Organisation\".id = {str_ID2}";
                                                cmd.ExecuteNonQuery();
                                            }
                                            else
                                            {
                                                Console.WriteLine("Некоректный Ввод");
                                            }
                                            break;
                                            //case 3:
                                            //    Console.WriteLine("Введите новый id дьявольский фрукт");
                                            //    int tempauthorid = 0;
                                            //    if (int.TryParse(Console.ReadLine(), out tempauthorid))
                                            //    {
                                            //        if (DFExists(tempauthorid))
                                            //        {
                                            //            cmd.CommandText = $"update \"Organisation\" set devil_id = {tempauthorid} where \"Organisation\".id = {str_ID2}";
                                            //            cmd.ExecuteNonQuery();
                                            //        }
                                            //        else
                                            //        {
                                            //            Console.WriteLine("Лидера с таким id, не существует");
                                            //        }
                                            //    }
                                            //    break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Некорректный ввод");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Нет персонада с таким id");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод");
                        }
                        break;
                    case 3:
                        int str_ID3 = 0;
                        Console.WriteLine("Введите id строки которую хотите изменить");
                        if (int.TryParse(Console.ReadLine(), out str_ID3))
                        {
                            Console.WriteLine("Введите новое название фрукта");
                            string tempDFname = Console.ReadLine();
                            cmd.CommandText = $"update \"Devil_Fruits\" set name = '{tempDFname}' where \"Devil_Fruits\".id = {str_ID3}";
                            cmd.ExecuteNonQuery();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод");
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод");
            }
        }
        public static void Deleter()
        {
            Console.WriteLine("Выберите таблицу");
            Console.WriteLine("\t1. Персонажи");
            Console.WriteLine("\t2. Организации");
            Console.WriteLine("\t3. Дьявольские фрукты");
            int input1 = 0;
            if (int.TryParse(Console.ReadLine(), out input1) && input1 >= 1 && input1 <= 3)
            {
                switch (input1)
                {
                    case 1:
                        int TEMPMINATOR = 0;
                        Console.WriteLine("Введите id строки которую хотите удалить");
                        if (int.TryParse(Console.ReadLine(), out TEMPMINATOR))
                        {
                            if (CharExists(TEMPMINATOR))
                            {
                                cmd.CommandText = $"delete from \"Characters\" where id = {TEMPMINATOR}";
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                Console.WriteLine("Некорректный id");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод");
                        }
                        break;
                    case 2:
                        int TEMPMINATOR2 = 0;
                        Console.WriteLine("Введите id строки которую хотите удалить");
                        if (int.TryParse(Console.ReadLine(), out TEMPMINATOR2))
                        {
                            if (CharExists(TEMPMINATOR2))
                            {
                                if (!CharacterDependet(TEMPMINATOR2))
                                {
                                    cmd.CommandText = $"delete from \"Organisation\" where id = {TEMPMINATOR2}";
                                    cmd.ExecuteNonQuery();
                                }
                                else
                                {
                                    Console.WriteLine("Так нельзя");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Некорректный id");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод");
                        }
                        break;
                    case 3:
                        int TEMPMINATOR3 = 0;
                        Console.WriteLine("Введите id строки которую хотите удалить");
                        if (int.TryParse(Console.ReadLine(), out TEMPMINATOR3))
                        {
                            if (CharExists(TEMPMINATOR3))
                            {
                                if (!DFDependet(TEMPMINATOR3))
                                {
                                    cmd.CommandText = $"delete from \"Devil_Fruits\" where id = {TEMPMINATOR3}";
                                    cmd.ExecuteNonQuery();
                                }
                                else
                                {
                                    Console.WriteLine("Так нельзя");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Некорректный id");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод");
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод");
            }
        }






}



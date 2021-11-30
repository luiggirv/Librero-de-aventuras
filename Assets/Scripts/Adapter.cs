using System;
using GameAuthoringAPI;
using UnityEngine;
using System.Collections.Generic;


public class LibreroAventurasGameStudent : GameStudent
{
    public List<LibreroAventurasStudentGameSessionConfig> gameSessionConfigs = new List<LibreroAventurasStudentGameSessionConfig>();
}

public class LibreroAventurasStudentGameSessionConfig : StudentGameSessionConfig
{
    /*
    public List<LAGameMission> gameMissions = new List<DCGameMission>();

    public class DCGameMission
    {
        private string name;
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        private bool isActive;
        public bool IsActive
        {
            get { return this.isActive; }
            set { this.isActive = value; }
        }
    */
    public List<Competence> competences = new List<Competence>();

    public class Competence
    {
        private string name;
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        private bool isActive;
        public bool IsActive
        {
            get { return this.isActive; }
            set { this.isActive = value; }
        }
        public List<Parameter> parameters = new List<Parameter>();
        public List<Competence> competences = new List<Competence>();
    }

    public class Parameter
    {
        private string name;
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        private string type;
        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
        private object _value;
        public object Value
        {
            get { return this._value; }
            set { this._value = value; }
        }
    }

}

//#pragma warning disable CS0436 // Type conflicts with imported type
public class LibreroAventurasGameAuthoringAPIAdapter : GameAuthoringAPIAdapter
//#pragma warning restore CS0436 // Type conflicts with imported type
{
    public const string GAME_ID = "12";
    public static LibreroAventurasGameStudent student;

    private static LibreroAventurasGameAuthoringAPIAdapter instance;
    private LibreroAventurasGameAuthoringAPIAdapter() { }
    public static LibreroAventurasGameAuthoringAPIAdapter Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new LibreroAventurasGameAuthoringAPIAdapter();
            }
            return instance;
        }
    }

    public override void ProcessGameStudentData(string token, Student student, Action<GameStudent> action)
    {
        LibreroAventurasGameStudent gameStudent = null;

        if (token != null && student != null)
        {
            gameStudent = new LibreroAventurasGameStudent();
            gameStudent.Username = student.User.Username;
            gameStudent.Email = student.User.Email;
            gameStudent.FirstName = student.User.FirstName;
            gameStudent.LastName = student.User.LastName;
            gameStudent.Institution = student.Institution;
            gameStudent.Token = token;
        }

        action(gameStudent);
    }

    public override void ProcessStudentGameConfigData(StudentGameConfig studentGameConfig, Action<StudentGameSessionConfig> action)
    {
        throw new NotImplementedException();
    }

    public override void ProcessStudentGameConfigsData(List<StudentGameConfig> studentGameConfigs, Action<List<StudentGameSessionConfig>> action)
    {
        List<StudentGameSessionConfig> studentGameSessionConfigs = new List<StudentGameSessionConfig>();

        for (int i = 0; i < studentGameConfigs.Count; i++)
        {
            StudentGameConfig studentGameConfigObj = studentGameConfigs[i];
            LibreroAventurasStudentGameSessionConfig laStudentGameSessionConfig = null;

            if (studentGameConfigObj != null && studentGameConfigObj.DgblConfig != null &&
                studentGameConfigObj.DgblConfig.IlosConfig != null &&
                studentGameConfigObj.DgblConfig.IlosConfig.Count > 0)
            {
                laStudentGameSessionConfig = new LibreroAventurasStudentGameSessionConfig();
                laStudentGameSessionConfig.Id = studentGameConfigObj.Id;
                laStudentGameSessionConfig.competences = new List<LibreroAventurasStudentGameSessionConfig.Competence>();
                for (int j = 0; j < studentGameConfigObj.DgblConfig.IlosConfig.Count; j++)
                {
                    LibreroAventurasStudentGameSessionConfig.Competence competence = new LibreroAventurasStudentGameSessionConfig.Competence();
                    competence.Name = studentGameConfigObj.DgblConfig.IlosConfig[j].Label;
                    competence.IsActive = studentGameConfigObj.DgblConfig.IlosConfig[j].IsActive;

                    if (studentGameConfigObj.DgblConfig.IlosConfig[j].IlosConfig != null &&
                        studentGameConfigObj.DgblConfig.IlosConfig[j].IlosConfig.Count > 0)
                    {
                        competence.competences = new List<LibreroAventurasStudentGameSessionConfig.Competence>();
                        for (int k = 0; k < studentGameConfigObj.DgblConfig.IlosConfig[j].IlosConfig.Count; k++)
                        {
                            LibreroAventurasStudentGameSessionConfig.Competence subCompetence = new LibreroAventurasStudentGameSessionConfig.Competence();
                            subCompetence.Name = studentGameConfigObj.DgblConfig.IlosConfig[j].IlosConfig[k].Label;
                            subCompetence.IsActive = studentGameConfigObj.DgblConfig.IlosConfig[j].IlosConfig[k].IsActive;
                            if (studentGameConfigObj.DgblConfig.IlosConfig[j].IlosConfig[k].IlosConfig != null &&
                                studentGameConfigObj.DgblConfig.IlosConfig[j].IlosConfig[k].IlosConfig.Count > 0)
                            {
                                for (int l = 0; l < studentGameConfigObj.DgblConfig.IlosConfig[j].IlosConfig[k].IlosConfig.Count; l++)
                                {
                                    LibreroAventurasStudentGameSessionConfig.Competence subSubCompetence = new LibreroAventurasStudentGameSessionConfig.Competence();
                                    subSubCompetence.Name = studentGameConfigObj.DgblConfig.IlosConfig[j].IlosConfig[k].IlosConfig[l].Label;
                                    subSubCompetence.IsActive = studentGameConfigObj.DgblConfig.IlosConfig[j].IlosConfig[k].IlosConfig[l].IsActive;
                                    subCompetence.competences.Add(subSubCompetence);

                                }
                            }
                            competence.competences.Add(subCompetence);
                        }
                    }
                    laStudentGameSessionConfig.competences.Add(competence);
                }
            }
            studentGameSessionConfigs.Add(laStudentGameSessionConfig);
        }
        action(studentGameSessionConfigs);
    }
}


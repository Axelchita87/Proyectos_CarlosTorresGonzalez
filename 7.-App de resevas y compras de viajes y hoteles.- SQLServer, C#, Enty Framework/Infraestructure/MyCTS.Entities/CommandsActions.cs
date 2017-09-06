using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Entities
{
    public class CommandsActions
    {

        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string command;
        public string Command
        {
            get { return command; }
            set { command = value; }
        }

        private string modulesname;
        public string ModulesName
        {
            get { return modulesname; }
            set { modulesname = value; }
        }

        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        private string commandtype;
        public string CommandType
        {
            get { return commandtype; }
            set { commandtype = value; }
        }

        private bool allow;
        public bool Allow
        {
            get { return allow; }
            set { allow = value; }
        }

        private string modulesrc;
        public string ModuleSrc
        {
            get { return modulesrc; }
            set { modulesrc = value; }
        }

        private List<string> commandsallowed;
        public List<string> CommandsAllowed
        {
            get { return commandsallowed; }
            set { commandsallowed = value; }
        }

        private List<string> commandsrestricted;
        public List<string> CommandsRestricted
        {
            get { return commandsrestricted; }
            set { commandsrestricted = value; }
        }

    }
}

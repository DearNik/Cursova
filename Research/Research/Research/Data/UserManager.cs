﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UserManager
{
    private static UserManager _instance;

    public static UserManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new UserManager();

            return _instance;
        }
    }

    public string Username { get; set; }
    public string Password { get; set; }
}

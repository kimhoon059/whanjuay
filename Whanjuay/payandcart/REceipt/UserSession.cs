using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whanjuay
{
    // คลาสนี้ใช้เก็บข้อมูลผู้ใช้ที่ล็อกอินอยู่
    public static class UserSession
    {
        // เราจะเก็บชื่อผู้ใช้ไว้ในนี้
        public static string CurrentUsername { get; set; }
    }
}
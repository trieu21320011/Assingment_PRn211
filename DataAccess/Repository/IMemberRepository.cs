﻿using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetMembers();
        Member GetMemberByID(int memberID);
        Member GetMemberByEmail(string memberEmail);
        void InsertMember(Member member);
        void DeleteMember(int memberID);
        void UpdateMember(Member member);

        Member CheckLogin(string email, string password);
    }
}

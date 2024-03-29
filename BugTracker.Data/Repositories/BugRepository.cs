﻿using BugTracker.Data.Entities;
using BugTracker.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Data.Repositories
{
    public class BugRepository : Repository<Bug>, IBugRepository
    {
        public BugRepository(IBugTrackerContext bugStoreContext) : base(bugStoreContext)
        {
        }
    }
}

﻿using Repositories.DTOs.BlogDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.BlogRepositories
{
    public interface IBlogRepository
    {
        List<GetBlogDTO> GetAll();
    }
}

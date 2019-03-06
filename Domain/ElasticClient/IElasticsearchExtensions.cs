using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ElasticClient
{
    public interface IElasticsearchExtensions
    {
        List<Employee> GetEmployees();

    }
}

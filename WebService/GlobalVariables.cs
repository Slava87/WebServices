using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using WebService.Models;

namespace WebService
{
    public enum NoYes
    {
        No,
        Yes
    }

    public enum SortType
    {
        Name,
        Type
    }

    public enum Commands
    {
        Show,
        Sort,
        Add,
        Edit,
        Delete,
        Load,
        Export,
        Exit
    }

    public enum DataType
    {
        XML,
        JSON,
    }

    public enum DataSource
    {
        DefaultLocation,
        ChooseManually,
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ServiceType
    {
        Education = 0,
        Commerce = 1,
        Service = 2,
        Entertainement = 4,
        Other = 3
    }

    public static class GlobalVariables
    {
        //public static string PathToXmlDefault = @"..\..\Data\services.xml";
        public static string InputPath = @"..\..\Data\services.xml";
        public static string OutputPath = @"..\..\Data\services.xml";

        public static DataSource InputDataSource = DataSource.DefaultLocation;
        public static DataSource OutputDataSource = DataSource.DefaultLocation;
        public static DataType InputDataType = DataType.XML;
        public static DataType OutputDataType = DataType.XML;
        public static SortType SortType = SortType.Name;
        public static Commands Command = Commands.Show;

        public static List<Service> Services = new List<Service>();
    }
}
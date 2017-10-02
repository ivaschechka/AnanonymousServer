namespace AnanonymousServer.Models
{
    public class Info
    {
        /// <summary>
        /// Путь к файлу 
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// Имя файла
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Данные для записи
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// Номер строки
        /// </summary>
        public string IdRow { get; set; }
    }
}

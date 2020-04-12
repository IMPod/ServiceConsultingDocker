using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataBase.Data.Enum;

namespace DataBase.Data
{
    public class BaseRecord : BaseEntity
    {
        /// <summary>
        /// Уникальнай идентификатор
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public long Id { get; set; }


        /// <summary>
        /// Состояние записи 
        /// </summary>
        [Column(Order = 1)]
        public RecordState RecState { get; set; }

        /// <summary>
        /// Дата создания записи
        /// </summary>
        public DateTime CreationDateTime { get; set; } = DateTime.UtcNow;
    }
}

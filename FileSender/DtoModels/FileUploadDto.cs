﻿namespace FileSender.DtoModels
{

    public class FileUploadDto
    {
        public Guid UploadId { get; set; }
        public DateTime? UploadDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}

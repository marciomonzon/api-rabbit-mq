﻿namespace ApiRabbitMQ
{
    public class SolicitacaoRelatorio
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Status { get; set; }
        public DateTime? ProcessedTime { get; set; }
    }
}

# Bank Application

Bu proje, .NET 9 kullanılarak geliştirilmiş bir bankacılık uygulamasının kredilendirme modülüdür.

## Proje Yapısı

Proje Clean Architecture ve CQRS pattern'leri kullanılarak geliştirilmiştir. Katmanlı mimari yapısı şu şekildedir:

- **Core**: Tüm katmanlar tarafından kullanılan ortak yapıları içerir
  - Base Entity yapıları
  - Generic Repository Pattern
  - Ortak utility sınıfları

- **Domain**: İş domainine ait entity'leri içerir
  - Customer (Base)
  - IndividualCustomer
  - CorporateCustomer

- **Application**: İş kuralları ve uygulama mantığını içerir
  - Repository Interfaces
  - Services
  - DTOs
  - CQRS Handlers

- **Persistence**: Veritabanı işlemlerini içerir
  - Entity Framework Core implementasyonları
  - Repository implementasyonları
  - DbContext ve konfigürasyonlar

- **WebApi**: API endpoint'lerini içerir

## Teknolojiler

- .NET 9
- Entity Framework Core 9
- SQL Server
- Clean Architecture
- CQRS Pattern
- Repository Pattern
------

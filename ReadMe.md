TestTaskHoff

## Introduction
Разработать REST API веб сервис определения курса иностранной валюты к рублю РФ на дату с учётом входных параметров и конфигурации.

## Application Architecture

Аутентификация на основе токена JWT

- **Identity Microservice** - 
- **Transaction Microservice** - 
- **API Gateway** - 

![Application Architecture](https://clip2net.com/clip/m0/4dfbe-clip-38kb.png?nocache=1)


## Technologies
- C#.NET
- ASP.NET WEB API Core


## WebApi Endpoints


1. Route: **"/user/authenticate"** [HttpPost] - 
UserName: test  
Password: test
2. Route: **"/account/GetCurrency"** [HttpGet] - пример тела запроса
{
    x:-0.5,
    y:-0.5,
    Radius:1,
    FromDate:null,
    ToDate:null,
    ValutaCode: "R01010"
}

- **Аутентификация**
![Аутентификация](https://clip2net.com/clip/m0/2c531-clip-56kb.png?nocache=1)
- **ошибка на некорректный код**
![ошибка на некорректный код](https://clip2net.com/clip/m0/a91df-clip-38kb.png?nocache=1)
- **ошибка на неверные координаты**
![ошибка на неверные координаты](https://clip2net.com/clip/m0/f762a-clip-36kb.png?nocache=1)
- **логирование ошибок**
![логирование ошибок](https://clip2net.com/clip/m0/78e7d-clip-245kb.png?nocache=1)

- **Что следует доделать**
    - Доделать логер
    - Распарсить ответ от ЦБ
    - Сделать мапер на ответ от ЦБ
    - Обработан только GetCursDynamic от ЦБ остальные даже не смотрел
    - Адрес  к сайту ЦБ прописан в коде 



- Sample data to test

| Username | Password |
| -------- | -------- |
|   test   | test     |


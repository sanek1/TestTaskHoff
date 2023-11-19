TestTaskHoff

## Introduction
Разработать REST API веб сервис определения курса иностранной валюты к рублю РФ на дату с учётом входных параметров и конфигурации.

## Application Architecture

Аутентификация на основе токена JWT

- **Identity Microservice** - 
- **Transaction Microservice** - 
- **API Gateway** - 

![Application Architecture](https://8dmbiq.dm.files.1drv.com/y4mKz6TDtiwhrfo2mdUgvzle36Bnj7PMCvY6fP6kixwU3c3_CMb_rnnYOxg9WKn8LMmc5F__p2w3NWJc0o1vmCFmhHd5hRbr0S4MnMFnx09qvdSHE_E_40H0pQOxE0om2T2czVDOAInkTXn4xgdx_FmRgo8OaBh2XYqFHTf2zmYmF71tqRqlLzlsYBo1x1_CvdCt8U6AbjMhYznbgeBkGUKPQ?width=625&height=243&cropmode=none)


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


![Аутентификация](https://clip2net.com/clip/m0/2c531-clip-56kb.png?nocache=1)
![ошибка на некорректный код](https://clip2net.com/clip/m0/a91df-clip-38kb.png?nocache=1)
![ошибка на неверные координаты](https://clip2net.com/clip/m0/f762a-clip-36kb.png?nocache=1)
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


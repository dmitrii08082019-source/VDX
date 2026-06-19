# VDX - Virtual Doc XP v1.0

**Virtual Document Explorer** — легковесный файловый менеджер с графическим интерфейсом для Windows, написанный на VB.NET.

![Version](https://img.shields.io/badge/version-1.0-blue)
![Platform](https://img.shields.io/badge/platform-Windows%207%2B-green)
![License](https://img.shields.io/badge/license-MIT-yellow)

---

## 📖 О проекте

**VDX (Virtual Doc XP)** — это минималистичный файловый менеджер, созданный для быстрой навигации по файловой системе. Программа работает как в среде Windows, так и в загрузочном режиме (WinPE).

### Возможности

- 📂 **Просмотр содержимого** папок и файлов
- 🧭 **Навигация** по истории (вперед/назад)
- 📁 **Создание** новых папок и файлов
- 🗑️ **Удаление** файлов и папок
- 📄 **Создание** VDX-файлов
- 🔍 **Проверка** существования пути
- ⌨️ **Горячие клавиши** для быстрого управления
- 💾 **Загрузочный режим** (опционально)

---

## 🚀 Быстрый старт

### Системные требования

- **Windows 7 / 8 / 10 / 11**
- **.NET Framework 4.5+** (установлен по умолчанию в Windows 10/11)
- **1 МБ свободного места** (основное приложение)
- **10-50 МБ** (загрузочный образ)

### Запуск

1. Скачайте последний релиз: [VDX.exe](https://github.com/yourusername/VDX/releases)
2. Запустите `VDX.exe`
3. Введите путь к папке в диалоговом окне
4. Наслаждайтесь работой!

---

## ⌨️ Горячие клавиши

| Клавиша | Действие |
|---------|----------|
| `Ctrl+Z` | Назад в истории |
| `Ctrl+Y` | Вперед в истории |
| `Delete` | Удалить выбранный элемент |
| `Ctrl+N` | Создать новый файл/папку |
| `Enter` | Открыть выбранный элемент |
| `Ctrl+F` | Поиск (планируется) |

---

## 🖼️ Интерфейс
┌─────────────────────────────────────────────────────┐
│ VDX - Virtual Doc XP v1.0 │
│ Is Active: True | Items: 42 │
│ Path: C:\Users\Admin\Documents │
│ │
│ [Check Path] [█████████████████████████] 100% │
│ │
│ ┌─────────────────────────────────────────────┐ │
│ │ Name Type Date Active │ │
│ │ Project Folder 2024-01-01 Yes │ │
│ │ Report.docx File 2024-01-02 Yes │ │
│ │ Photo.jpg File 2024-01-03 Yes │ │
│ │ ... │ │
│ └─────────────────────────────────────────────┘ │
│ │
│ [<] [>] [New] [Delete] [New VDX] │
└─────────────────────────────────────────────────────┘

text

---

## 📁 Структура проекта
VDX/
├── Module1.vb # Главный модуль запуска
├── VdxForm.vb # Основная форма приложения
├── VdxForm.Designer.vb # Дизайн формы (генерация)
├── Vdx.exe # Скомпилированное приложение
├── README.md # Этот файл
└── LICENSE # Лицензия MIT

text

---

## 🔧 Сборка проекта

### Требования для сборки

- **Visual Studio 2019/2022**
- **.NET Framework 4.5 SDK**

### Шаги сборки

1. Клонируйте репозиторий:
   ```bash
   git clone https://github.com/yourusername/VDX.git
Откройте проект в Visual Studio:

text
File → Open → Project/Solution
Выберите VDX.vbproj
Соберите проект:

text
Build → Build Solution
Готовый файл VDX.exe появится в папке bin/Release/

💾 Загрузочный образ (опционально)
VDX может работать как загрузочная система вместо Windows.

Создание загрузочного VDX
powershell
# 1. Скачать Windows ADK (WinPE)
# https://learn.microsoft.com/ru-ru/windows-hardware/get-started/adk-install

# 2. Создать WinPE
copype amd64 C:\VDX_PE

# 3. Скопировать VDX
copy VDX.exe C:\VDX_PE\media\Windows\System32\VDX\

# 4. Создать winpeshl.ini
echo [LaunchApps] > C:\VDX_PE\media\Windows\System32\winpeshl.ini
echo X:\Windows\System32\VDX\VDX.exe >> C:\VDX_PE\media\Windows\System32\winpeshl.ini

# 5. Удалить sources (чтобы не запускалась установка)
rmdir /s /q C:\VDX_PE\media\sources

# 6. Создать ISO
MakeWinPEMedia /ISO C:\VDX_PE C:\VDX_Boot.iso
Запись на USB
С помощью Win32 Disk Imager:

Скачайте Win32 Disk Imager

Выберите USB-накопитель

Выберите VDX_Boot.iso

Нажмите Write

С помощью PowerISO:

Откройте VDX_Boot.iso

Insert USB → Tools → Burn to USB Drive

Нажмите Burn

📊 Размеры
Компонент	Размер
VDX.exe (приложение)	~200 КБ
С зависимостями (.NET)	~1-2 МБ
Загрузочный образ (WinPE)	~10-15 МБ
Полный образ (с sources)	~300-500 МБ
🛠️ Технологии
Язык: VB.NET

Платформа: .NET Framework 4.5+

Графический интерфейс: Windows Forms

Сборка: Visual Studio 2022

📝 Лицензия
Проект распространяется под лицензией MIT. Подробнее в файле LICENSE.

text
MIT License

Copyright (c) 2024 VDX Project

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction...
🤝 Вклад в проект
Мы приветствуем любую помощь!

Форкните репозиторий

Создайте ветку для вашей фичи (git checkout -b feature/AmazingFeature)

Зафиксируйте изменения (git commit -m 'Add some AmazingFeature')

Запушьте в ветку (git push origin feature/AmazingFeature)

Откройте Pull Request

Идеи для улучшения
Добавить поиск файлов

Поддержка темной темы

Копирование/перемещение файлов

Просмотр изображений

Встроенный текстовый редактор

Поддержка сетевых папок

📞 Контакты
Автор: Ваше Имя

Email: your.email@example.com

GitHub: https://github.com/yourusername/VDX

🙏 Благодарности
Microsoft WinPE

Win32 Disk Imager

PowerISO

VB.NET Community

📌 Важное примечание
VDX создан как учебный проект и не предназначен для замены полноценных файловых менеджеров вроде Total Commander или Windows Explorer.

© 2024 VDX - Virtual Doc XP. Все права защищены.

Сделано с ❤️ на VB.NET

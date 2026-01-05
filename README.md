https://github.com/user-attachments/assets/4b04ace5-cc22-4df5-b009-bae771c62232
# 🎓 Attend5 — Student Attendance Tracking

![Status](https://img.shields.io/badge/Status-Active-green)
![C#](https://img.shields.io/badge/Language-C%23-blue)

`Attend5` — **C# konsol dasturi**, Excel fayllardan studentlarning qatnashuv ma’lumotlarini o‘qib, ularni chiroyli ko‘rinishda konsolga chiqaradi.

---

## 🎬 Demo Video

[▶ Videoni ko‘rish](Assets/videoNamuna.mp4)

---

## 🔹 Asosiy imkoniyatlar

- Excel fayldan `ExternalAttendance` ma’lumotlarini o‘qish  
- Studentlar bo‘yicha `ParticipationMinutes` hisoblash  
- Studentlar ro‘yxatini turli ko‘rinishlarda konsolga chiqarish:
  - To‘liq jadval
  - Ism, Familiya va ID
  - Ism va qatnashgan vaqt
- Qidiruv imkoniyatlari:
  - ID bo‘yicha
  - Ism bo‘yicha
  - Familiya bo‘yicha
- Familiyani o‘zgartirish va studentni ID bo‘yicha o‘chirish  
- Natijalarni **ramkalar va chiroyli formatda** konsolga chiqarish

---

## 🔹 Loyihaning tuzilishi

```text
Attend5/
│
├─ Domain.Models/
│   └─ ExternalAttendance.cs
│   └─ StudentAttend.cs
│
├─ Infrastructure.Data/
│   └─ FileContext.cs
│   └─ DbContext.cs
│
├─ Application.Service/
│   └─ ExternalAttendanceService.cs
│   └─ StudentAttendServices.cs
│
└─ Client/
    └─ Program.cs



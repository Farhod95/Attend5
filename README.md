https://github.com/user-attachments/assets/4b04ace5-cc22-4df5-b009-bae771c62232
# Attend5 — Student Attendance Tracking

![Attendance](https://img.shields.io/badge/Status-Active-green)

`Attend5` loyihasi **C# konsol dasturi** bo‘lib, Excel fayllardan studentlarning qatnashuv ma’lumotlarini o‘qib, ularni qayta ishlash va chiroyli ko‘rinishda konsolga chiqarish imkonini beradi.  

---

## 🔹 Asosiy imkoniyatlar

- Excel fayldan `ExternalAttendance` ma’lumotlarini o‘qish  
- Studentlar bo‘yicha `ParticipationMinutes` hisoblash  
- Studentlar ro‘yxatini turli ko‘rinishlarda ekranga chiqarish:  
  - To‘liq jadval  



  - Ism, familiya va ID  
  - Ism va qatnashgan vaqt  
- Qidiruv imkoniyatlari:  
  - ID bo‘yicha  
  - Ism bo‘yicha  
  - Familiya bo‘yicha  
- Natijalarni **chiroyli ramkalar bilan konsolga chiqarish**

---

## 🔹 Loyihaning strukturasi


- **Domain.Models** – ma’lumot modellari (`ExternalAttendance`, `StudentAttend`)  
- **Infrastructure.Data** – Excel faylni o‘qish va ma’lumotlarni `DbContext` orqali qayta ishlash  
- **Application.Service** – biznes logika, konsolga ma’lumot chiqarish va qidiruvlar  
- **Client** – konsol dasturining `Main` entry point  

---

## 🔹 Ishlash prinsipi

1. **Excel fayl** (`fixed_attendance.xlsx`) `FileContext` orqali o‘qiladi.  
2. `DbContext` yordamida `ExternalAttendance` ma’lumotlaridan `StudentAttend` jadvali hosil qilinadi.  
3. Foydalanuvchi konsol menyusidan tanlov qiladi:  

| Tanlov | Amal |
|--------|------|
| 1      | Excel ro‘yxatini chiqarish |
| 2      | Yangi jadvalni to‘liq ko‘rish |
| 3      | Ism, Familiya va ID ko‘rish |
| 4      | Ism va qatnashgan vaqtini ko‘rish |
| 5      | ID bo‘yicha qidiruv |
| 6      | Ism bo‘yicha qidiruv |
| 7      | Familiya bo‘yicha qidiruv |

4. Har bir natija **“********” ramkalar bilan** chiroyli ko‘rinishda chiqariladi.  

---

## 🔹 Texnologiyalar

- C# .NET 6+  
- OfficeOpenXml (EPPlus) — Excel fayllar bilan ishlash uchun  
- LINQ — ma’lumotlarni filtrlash va qidirish  

---

## 🔹 Misol ekranga chiqarish

**Yangi jadval:**


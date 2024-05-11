import React, { useEffect } from "react";
import backgroundImage from "@/assets/Burning2jpg.jpg"; // Путь к изображению

export default function HomePage() {
  useEffect(() => {
    // Изменение заголовка документа здесь
    document.title = "Главная";
  }, []);

  return (
    <div style={{ 
      backgroundImage: `url(${backgroundImage})`, // Установка изображения в качестве фона
      backgroundSize: 'cover', // Масштабирование изображения по размеру контейнера
      display: 'flex', 
      justifyContent: 'center', 
      alignItems: 'center', 
      height: '80vh',
      backgroundColor: 'transparent' // Установка прозрачного фона
    }}>
      <h1 style={{ 
        textAlign: 'center',
        color: '#fff', // Установка цвета текста
        textShadow: '2px 2px 4px rgba(0, 0, 0, 1)'
      }}>
        Разработка информационной системы расчета горения всех видов топлив
      </h1>
    </div>
  );
}
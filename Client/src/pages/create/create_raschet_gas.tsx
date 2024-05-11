import { useParams, history } from "@umijs/max";
import request from "@/utils/request";
import { Button, Form, message, Spin } from "antd";
import FormRaschetEditGasFuelBurn from "@/components/FormRaschetEditGasFuelBurn";
import React, { useEffect, useState } from "react";

const DocsPage = (props: any) => {
  const [initialData, setInitialData] = useState<GasModel | null>(null); // Состояние для хранения исходных данных

  useEffect(() => {
    // Вызов метода GET для получения исходных данных
    request(`https://localhost:7050/HomeController2/DataInputAdd`, { method: 'GET', initialData }).then(result => {
      setInitialData(result); // Сохранение полученных данных в состоянии
    }).catch(error => {
      console.error("Ошибка при получении исходных данных:", error);
    });
  }, []);

  const createHandler = (formData: GasModel) => {
    if (!formData || !formData.gasFuelModel) {
      console.error("Ошибка: Неверная структура данных formData");
      return;
    }
  
    // Создание объекта для отправки
    const dataToSend = {
      name: formData.name,
      description: formData.description,
      typeCalculation: formData.typeCalculation,
      gasFuelModel: {
        cO2: formData.gasFuelModel.cO2,
        co: formData.gasFuelModel.co,
        h2: formData.gasFuelModel.h2,
        cH4: formData.gasFuelModel.cH4,
        c2H6: formData.gasFuelModel.c2H6,
        c3H8: formData.gasFuelModel.c3H8,
        c4H10: formData.gasFuelModel.c4H10,
        c5H12: formData.gasFuelModel.c5H12,
        h2S: formData.gasFuelModel.h2S,
        n2: formData.gasFuelModel.n2,
        h2O: formData.gasFuelModel.h2O,
        g: formData.gasFuelModel.g,
        tг: formData.gasFuelModel.tг,
        tв: formData.gasFuelModel.tв,
        alfa: formData.gasFuelModel.alfa
      }
    };
  
    // Отправка POST запроса с данными формы
    request(`https://localhost:7050/HomeController2/DataInputAdd`, { method: 'POST', data: dataToSend }).then(result => {
      history.push('/raschet_gas_fuel');
      message.success("Запись добавлена");
    }).catch(error => {
      console.error("Ошибка при добавлении записи:", error);
    });
  };

  return (
    <>
      {initialData ? ( // Проверка, что данные получены
        <Form onFinish={createHandler} initialValues={initialData}> {/* Передача исходных данных в форму */}
          <FormRaschetEditGasFuelBurn initialValues={initialData}/>
          <Button type="primary" htmlType="submit">Сохранить</Button>
        </Form>
      ) : (
        <Spin /> // Отображение спиннера во время загрузки данных
      )}
    </>
  );
};

export default DocsPage;

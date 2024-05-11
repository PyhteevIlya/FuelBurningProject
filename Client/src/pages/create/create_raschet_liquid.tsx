import { useParams, history } from "@umijs/max";
import request from "@/utils/request";
import { Button, Form, message, Spin } from "antd";
import FormRaschetEditLiquidFuelBurn from "@/components/FormRaschetEditLiquidFuelBurn";
import React, { useEffect, useState } from "react";

const DocsPage = (props: any) => {
  const [initialData, setInitialData] = useState<LiquidModel | null>(null); // Состояние для хранения исходных данных

  useEffect(() => {
    // Вызов метода GET для получения исходных данных
    request(`https://localhost:7050/LiquidController2/DataInputAdd`, { method: 'GET', initialData }).then(result => {
      setInitialData(result); // Сохранение полученных данных в состоянии
    }).catch(error => {
      console.error("Ошибка при получении исходных данных:", error);
    });
  }, []);

  const createHandler = (formData: LiquidModel) => {
    if (!formData || !formData.liquidFuelModel) {
      console.error("Ошибка: Неверная структура данных formData");
      return;
    }
    
    // Создание объекта для отправки
    const dataToSend = {
      name: formData.name,
      description: formData.description,
      typeCalculation: formData.typeCalculation,
      liquidFuelModel: {
        c: formData.liquidFuelModel.c,
        h: formData.liquidFuelModel.h,
        s: formData.liquidFuelModel.s,
        n: formData.liquidFuelModel.n,
        o: formData.liquidFuelModel.o,
        wp: formData.liquidFuelModel.wp,
        ap: formData.liquidFuelModel.ap,
        t_v: formData.liquidFuelModel.t_v,
        t_t: formData.liquidFuelModel.t_t,
        alfaG: formData.liquidFuelModel.alfaG,
        m_недожог: formData.liquidFuelModel.m_недожог,
        gg: formData.liquidFuelModel.gg
      }
    };

    // Отправка POST запроса с данными исходной формы
    request(`https://localhost:7050/LiquidController2/DataInputAdd`, { method: 'POST', data: dataToSend }).then(result => {
      history.push('/raschet_liquid_fuel');
      message.success("Запись добавлена");
    }).catch(error => {
      console.error("Ошибка при добавлении записи:", error);
    });
  };

  return (
    <>
      {initialData ? ( // Проверка, что данные получены
        <Form onFinish={createHandler} initialValues={initialData}> {/* Передача исходных данных в форму */}
          <FormRaschetEditLiquidFuelBurn initialValues={initialData}/>
          <Button type="primary" htmlType="submit">Сохранить</Button>
        </Form>
      ) : (
        <Spin /> // Отображение спиннера во время загрузки данных
      )}
    </>
  );
};

export default DocsPage;

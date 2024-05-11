import request from "@/utils/request";
import { Button, Form, Input, Modal, Select } from "antd";
import React from "react";

export default (props: any) => {



    return (
        <>
            <Form.Item name="name" label="Название варианта исходных данных">
                <Input placeholder="Введите название" />
            </Form.Item>

            <Form.Item name="description" label="Описание">
                <Input placeholder="Введите описание" />
            </Form.Item>

            <Form.Item name="wstart" label="Начальная влажность материала">
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name="wend" label="Конечная влажность материала" >
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name="percentCp" label="Содержание углерода в топливе" >
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name="percentHp" label="Содержание водорода в топливе" >
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name="percentSp" label="Содержание серы в топливе" >
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name="percentOp" label="Содержание кислорода в топливе" >
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name="percentNp" label="Содержание азота в топливе" >
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name="percentAp" label="Содержание золы в топливе" >
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name="percentWp" label="Содержание влаги в топливе" >
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name="t1" label="Максимальная температура газов, градусов цельсия" >
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name="t2" label="Минимальная температура газов, градусов цельсия" >
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name="alpha" label="Коэффициент расхода воздуха" >
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name="eta" label="Коэффициент сохранения тепла" >
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name="tair" label="Температура воздуха, градусов цеьсия" >
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name="tgase" label="Температура газов, градусов цеьсия" >
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name="tm1" label="Средняя по массе начальная температура материала, градусов цельсия" >
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name="gt" label="Требуемая производительность, кг/ч" >
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name="him" label="Процент химического недожога" >
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name="k" label="Объемное отношение кислорода к азоту в воздухе" >
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name="cgase" label="Удельная теплоемкость газов, кДж/(кг*К)" >
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name="cmaterial" label="Удельная теплоемкость сухого материала, кДж/(кг*К)" >
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name="cwet" label="Удельная теплоемкость влаги, кДж/(кг*К)" >
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name="enthalpy100" label="Энтальпия водяного пара при 100 градусах цельсия, кДж/кг" >
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name="d" label="Диаметр барабана, м" >
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name="l" label="Длина барабана, м" >
                <Input placeholder="Введите значение" />
            </Form.Item>


        </>
    );
};


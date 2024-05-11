import request from "@/utils/request";
import { Button, Form, Input, Modal, Select } from "antd";
import React from "react";

interface FormRaschetEditLiquidFuelBurnProps {
    initialValues: LiquidModel; // Указываем тип для initialValues
  }
const FormRaschetEditLiquidFuelBurn: React.FC<FormRaschetEditLiquidFuelBurnProps> = ({ initialValues }) => {

    return (
        <>
            <Form.Item name="name" label="Название варианта исходных данных"initialValue={initialValues.name}>
                <Input placeholder="Введите название" />
            </Form.Item>

            <Form.Item name="typeCalculation" label="Тип расчета"initialValue={initialValues.typeCalculation}>
                <Input placeholder="Введите тип" disabled/>
            </Form.Item>

            <Form.Item name="description" label="Описание"initialValue={initialValues.description}>
                <Input placeholder="Введите описание" />
            </Form.Item>

            <Form.Item name={["liquidFuelModel", "c"]} label="Масса C,%"initialValue={initialValues.liquidFuelModel.c}>
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name={["liquidFuelModel", "h"]} label="Масса H,%"initialValue={initialValues.liquidFuelModel.h}>
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name={["liquidFuelModel", "s"]} label="Масса S,%"initialValue={initialValues.liquidFuelModel.s}>
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name={["liquidFuelModel", "n"]} label="Масса N,%"initialValue={initialValues.liquidFuelModel.n}>
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name={["liquidFuelModel", "o"]} label="Масса O"initialValue={initialValues.liquidFuelModel.o}>
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name={["liquidFuelModel", "wp"]} label="Содержание влаги в топливе, масс. Wp,%"initialValue={initialValues.liquidFuelModel.wp}>
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name={["liquidFuelModel", "ap"]} label="Содержание золы в топливе, масс. Ap,%"initialValue={initialValues.liquidFuelModel.ap}>
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name={["liquidFuelModel", "t_v"]} label="Температура подогрева воздуха перед горением, °С"initialValue={initialValues.liquidFuelModel.t_v}>
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name={["liquidFuelModel", "t_t"]} label="Температура подогрева топлива перед горением, С"initialValue={initialValues.liquidFuelModel.t_t}>
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name={["liquidFuelModel", "alfaG"]} label="Коэф.расхода воздуха на горение"initialValue={initialValues.liquidFuelModel.alfaG}>
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name={["liquidFuelModel", "m_недожог"]} label="Механический недожог топлива, % к теплоте сгорания топлива"initialValue={initialValues.liquidFuelModel.m_недожог}>
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name={["liquidFuelModel", "gg"]} label="Влагосодержание воздуха, г/м3 сухого воздуха"initialValue={initialValues.liquidFuelModel.gg}>
                <Input placeholder="Введите значение" />
            </Form.Item>
        </>
    );
};
export default FormRaschetEditLiquidFuelBurn;

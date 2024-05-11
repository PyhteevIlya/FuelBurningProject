import request from "@/utils/request";
import { Button, Form, Input, Modal, Select } from "antd";
import React from "react";

interface FormRaschetEditGasFuelBurnProps {
    initialValues: GasModel; // Указываем тип для initialValues
  }
const FormRaschetEditGasFuelBurn: React.FC<FormRaschetEditGasFuelBurnProps> = ({ initialValues }) => {

    return (
        <>
            <Form.Item name="name" label="Название варианта исходных данных"initialValue={initialValues.name}>
                <Input placeholder="Введите название" />
            </Form.Item>

            <Form.Item name="typeCalculation" label="Тип расчета"initialValue={initialValues.typeCalculation}>
                <Input placeholder="Введите тип" disabled/>
            </Form.Item>

            <Form.Item name="description" label="Описание" initialValue={initialValues.description}>
                <Input placeholder="Введите описание" />
            </Form.Item>

            <Form.Item name={["gasFuelModel", "cO2"]} label="Масса CO2,%"initialValue={initialValues.gasFuelModel.cO2}>
                <Input placeholder="Введите значение"/>
            </Form.Item>

            <Form.Item name={["gasFuelModel", "co"]} label="Масса CO,%" initialValue={initialValues.gasFuelModel.co}>
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name={["gasFuelModel", "h2"]} label="Масса H2,%" initialValue={initialValues.gasFuelModel.h2}>
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name={["gasFuelModel", "cH4"]} label="Масса CH4,%" initialValue={initialValues.gasFuelModel.cH4}>
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name={["gasFuelModel", "c2H6"]} label="Масса C2H6,%" initialValue={initialValues.gasFuelModel.c2H6}>
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name={["gasFuelModel", "c3H8"]} label="Масса C3H8,%" initialValue={initialValues.gasFuelModel.c3H8} >
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name={["gasFuelModel", "c4H10"]} label="Масса C4H10,%" initialValue={initialValues.gasFuelModel.c4H10}>
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name={["gasFuelModel", "c5H12"]} label="Масса C5H12,%" initialValue={initialValues.gasFuelModel.c5H12}>
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name={["gasFuelModel", "h2S"]} label="Масса H2S,%" initialValue={initialValues.gasFuelModel.h2S}>
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name={["gasFuelModel", "n2"]} label="Масса N2,%" initialValue={initialValues.gasFuelModel.n2}>
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name={["gasFuelModel", "h2O"]} label="Масса H2O,%" initialValue={initialValues.gasFuelModel.h2O}>
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name={["gasFuelModel", "g"]} label="Влагосодержание воздуха g, г/м3 сухого воздуха" initialValue={initialValues.gasFuelModel.g}>
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name={["gasFuelModel", "tг"]} label="Температура подогрева топлива перед горением t_г, С" initialValue={initialValues.gasFuelModel.tг}>
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name={["gasFuelModel", "tв"]} label="Температура подогрева врздуха перед горением t_в, С" initialValue={initialValues.gasFuelModel.tв}>
                <Input placeholder="Введите значение" />
            </Form.Item>

            <Form.Item name={["gasFuelModel", "alfa"]} label="Коэф.расхода воздуха на горение" initialValue={initialValues.gasFuelModel.alfa}>
                <Input placeholder="Введите значение" />
            </Form.Item>
        </>
        
    );
};
export default FormRaschetEditGasFuelBurn;

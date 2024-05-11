import { useParams } from "@/.umi/exports";
import request from "@/utils/request";
import { Pie } from "@ant-design/plots";
import { Space, DescriptionsProps, Descriptions, Button } from "antd";
import React, { useRef, useState } from "react";
import ReactToPrint from "react-to-print";


const PrintComponent = ({ data, items, items2, items3, charts, config }) => (
  <>
            <Space direction="vertical" style={{ marginBottom: '10px' }}>

            </Space>

            <div>
                <h2 style={{ textAlign: 'center' }}>Исходные данные</h2>
                <Descriptions
                    bordered
                    layout="vertical"
                    size="middle"
                    items={items3} />
            </div>

			  <div>
				<h2 style={{ textAlign: 'center' }}>Итоговые расчетные показатели</h2>
				<Descriptions
				  bordered
				  layout="vertical"
				  size="middle"
				  items={items2} />
			  </div>

				<div>
				  <h2 style={{ textAlign: 'center' }}>Промежуточные показатели</h2>
				  <Descriptions
					bordered
					layout="vertical"
					labelStyle={{ textAlign: 'center' }}
					size="middle"
					items={items} />
				</div>

            <div style={{ textAlign: 'center' }}>
                <h2>Расчет температур</h2>
                <Pie {...config} />
            </div>


        </>
    );

const DocsPage = (props: any) => {
    const params = useParams();
    const [data, setData] = React.useState<any>();
	const componentRef = useRef();


    React.useEffect(() => {
        request(`https://localhost:7050/HomeController2/Report?id=${params.id}`).then(result => {
            console.log(result);
            setData(result)
        });
    }, []);

    const roundNumber = (value) => {
        // Округлить значение до двух знаков после запятой
        return Number(value).toFixed(3);
    };

    const items3: DescriptionsProps['items'] = [
        { label: 'Название варианта исходных данных', children: data?.dataInput.name, span: 2, },
        { label: 'Тип расчета', children: data?.dataInput.typeCalculation, },
        { label: 'Описание', children: data?.dataInput.description,  },
        { label: 'Масса CO2,%', children: roundNumber(data?.dataInput.gasFuelModel.cO2), },
        { label: 'Масса CO,%', children: roundNumber(data?.dataInput.gasFuelModel.co), },
        { label: 'Масса H2,%', children: roundNumber(data?.dataInput.gasFuelModel.h2), },
        { label: 'Масса CH4,%', children: roundNumber(data?.dataInput.gasFuelModel.cH4), },
        { label: 'Масса C2H6,%', children: roundNumber(data?.dataInput.gasFuelModel.c2H6), },
        { label: 'Масса C3H8,%', children: roundNumber(data?.dataInput.gasFuelModel.c3H8), },
        { label: 'Масса C4H10,%', children: roundNumber(data?.dataInput.gasFuelModel.c4H10), },
        { label: 'Масса C5H12,%', children: roundNumber(data?.dataInput.gasFuelModel.c5H12), },
        { label: 'Масса H2S,%', children: roundNumber(data?.dataInput.gasFuelModel.h2S), },
        { label: 'Масса N2,%', children: roundNumber(data?.dataInput.gasFuelModel.n2), },
        { label: 'Масса H2O,%', children: roundNumber(data?.dataInput.gasFuelModel.h2O), },
        { label: 'Влагосодержание воздуха g, г/м3 сухого воздуха', children: roundNumber(data?.dataInput.gasFuelModel.g), },
        { label: 'Температура подогрева топлива перед горением t_г, С', children: roundNumber(data?.dataInput.gasFuelModel.tг), },
        { label: 'Температура подогрева врздуха перед горением t_в, С', children: roundNumber(data?.dataInput.gasFuelModel.tв), },
        { label: 'Коэф.расхода воздуха на горение', children: roundNumber(data?.dataInput.gasFuelModel.alfa), },
    ]

  //Промежуточные показатели
  const items: DescriptionsProps['items'] = [
    { label: 'Рабочая масса Rh2o,%', children: roundNumber(data?.rezult.rh2o), },
    { label: 'Рабочая масса CO2,%', children: roundNumber(data?.rezult.rco2), },
    { label: 'Рабочая масса CO,%', children: roundNumber(data?.rezult.rco), },
    { label: 'Рабочая масса H2,%', children: roundNumber(data?.rezult.rh2), },
    { label: 'Рабочая масса CH4,%', children: roundNumber(data?.rezult.rch4), },
    { label: 'Рабочая масса C2H6,%', children: roundNumber(data?.rezult.rc2h6), },
    { label: 'Рабочая масса C3H8,%', children: roundNumber(data?.rezult.rc3h8), },
    { label: 'Рабочая масса C4H10,%', children: roundNumber(data?.rezult.rc4h10), },
    { label: 'Рабочая масса C5H12,%', children: roundNumber(data?.rezult.rc5h12), },
    { label: 'Рабочая масса H2S,%', children: roundNumber(data?.rezult.rh2s), },
    { label: 'Рабочая масса N2,%', children: roundNumber(data?.rezult.rN2), },
    { label: 'Рабочая масса H2O,%', children: roundNumber(data?.rezult.sumishdanrab), },
  ];

  //Расчетные показатели
  const items2: DescriptionsProps['items'] = [
    { label: 'Теоретический расход окислителя на горение Lo, м3/м3', children: roundNumber(data?.rezult.lo), },
    { label: 'Действительный расход окислителя на горение L_alfa, м3/м3', children: roundNumber(data?.rezult.lalfa), },
    { label: 'Количество CO2 в продуктах горения, м3/м3', children: roundNumber(data?.rezult.vo_CO2), },
    { label: 'Количество SO2 в продуктах горения, м3/м3', children: roundNumber(data?.rezult.vo_SO2), },
    { label: 'Количество H2O в продуктах горения, м3/м3', children: roundNumber(data?.rezult.vo_H2O), },
    { label: 'Количество N2 в продуктах горения, м3/м3', children: roundNumber(data?.rezult.vo_N2), },
    { label: 'Количество CO в продуктах горения, м3/м3', children: roundNumber(data?.rezult.vo_CO), },
    { label: 'Количество H2 в продуктах горения, м3/м3', children: roundNumber(data?.rezult.vo_H2), },
    { label: 'Количество O2 в продуктах горения, м3/м3', children: roundNumber(data?.rezult.vo_O2), },
    { label: 'Теоретический объем продуктов горения, м3/м3', children: roundNumber(data?.rezult.vo), },
    { label: 'Практический выход N2 при избытке окислителя, м3/м3', children: roundNumber(data?.rezult.v_alfa_N2), },
    { label: 'Количество избыточного кислорода в продуктах горения, м3/м3', children: roundNumber(data?.rezult.v_O2_izb), },
    { label: 'Действительное количество продуктов горения, м3/м3 V_alfa', children: roundNumber(data?.rezult.v_alfa), },
    { label: 'Содежание CO2 в продуктах горения, % CO2', children: roundNumber(data?.rezult.cO2alfa), },
    { label: 'Содежание CO2 в продуктах горения, % CO2 при alfa2', children: roundNumber(data?.rezult.cO2alfa2), },
    { label: 'Содержание SO2 в продуктах горения, % SO2', children: roundNumber(data?.rezult.sO2alfa), },
    { label: 'Содержание SO2 в продуктах горения, % SO2 при alfa2', children: roundNumber(data?.rezult.sO2alfa2), },
    { label: 'Содежание H2O в продуктах горения, % H2O', children: roundNumber(data?.rezult.h2Oalfa), },
    { label: 'Содежание H2O в продуктах горения, % H2O при alfa2', children: roundNumber(data?.rezult.h2Oalfa2), },
    { label: 'Содержание N2 в продуктах горения, % N2', children: roundNumber(data?.rezult.n2alfa), },
    { label: 'Содержание N2 в продуктах горения, % N2 при alfa2', children: roundNumber(data?.rezult.n2alfa2), },
    { label: 'Содежание CO в продуктах горения (диссоциация), % CO', children: roundNumber(data?.rezult.cOalfa), },
    { label: 'Содежание CO в продуктах горения (диссоциация), % CO при alfa2', children: roundNumber(data?.rezult.cOalfa2), },
    { label: 'Содержание H2 в продуктах горения (диссоциация), % H2', children: roundNumber(data?.rezult.h2alfa), },
    { label: 'Содержание H2 в продуктах горения (диссоциация), % H2 при alfa2', children: roundNumber(data?.rezult.h2alfa2), },
    { label: 'Содежание O2 в продуктах горения, % O2', children: roundNumber(data?.rezult.o2alfa), },
    { label: 'Содежание O2 в продуктах горения, % O2 при alfa2', children: roundNumber(data?.rezult.o2alfa2), },
    { label: 'Общая процентная сумма всех компонентов (должна быть 100 %), % Сумма', children: roundNumber(data?.rezult.sumalfa), },
    { label: 'Общая процентная сумма всех компонентов (должна быть 100 %), % Сумма  при alfa2', children: roundNumber(data?.rezult.sumalfa2), },
    { label: 'Теплота сгорания топлива, кДж/(м3) Q н.р.', children: roundNumber(data?.rezult.qнр), },
    { label: 'Удельная теплоемкость газообразного топлива, кДж/(м3 * °С', children: roundNumber(data?.rezult.cтопл), },
    { label: 'Удельная теплоемкость воздуха, кДж/(м3 * °С)', children: roundNumber(data?.rezult.cвозд), },
    { label: 'Содержание воздуха в продуктах горения, %', children: roundNumber(data?.rezult.воздВПГ), },
    { label: 'Химическая энтальпия топлива, кДж/м^3 i_хим', children: roundNumber(data?.rezult.i_химalfa), },
    { label: 'Химическая энтальпия топлива, кДж/м^3 i_хим', children: roundNumber(data?.rezult.i_химalfa2), },
    { label: 'Физическая энтальпия подогрева топлива, кДж/м^3 i_топл', children: roundNumber(data?.rezult.i_топлalfa), },
    { label: 'Физическая энтальпия подогрева топлива, кДж/м^3 i_топл', children: roundNumber(data?.rezult.i_топлalfa2), },
    { label: 'Физическая энтальпия подогрева воздуха, кДж/м^3 i_возд', children: roundNumber(data?.rezult.i_воздalfa), },
    { label: 'Физическая энтальпия подогрева воздуха, кДж/м^3 i_возд', children: roundNumber(data?.rezult.i_воздalfa2), },
    { label: 'Общая (теоретическая) энтальпия продуктов горения, кДж/м^3', children: roundNumber(data?.rezult.i_общ_т_alfa), },
    { label: 'Общая (теоретическая) энтальпия продуктов горения, кДж/м^3', children: roundNumber(data?.rezult.i_общ_т_alfa2), },
    { label: 'Энтальпия химического недожога, кДж/м^3', children: roundNumber(data?.rezult.i_з_alfa), },
    { label: 'Энтальпия химического недожога, кДж/м^3', children: roundNumber(data?.rezult.i_з_alfa2), },
    { label: 'Общая балансовая энтальпия продуктов горения, кДж/м^3 i_общ_б', children: roundNumber(data?.rezult.i_общ_б_alfa), },
    { label: 'Общая балансовая энтальпия продуктов горения, кДж/м^3 i_общ_б', children: roundNumber(data?.rezult.i_общ_б_alfa2), },
    { label: 'Теоретическая температура, °С', children: roundNumber(data?.rezult.temp_alfa), },
    { label: 'Теоретическая температура, °С', children: roundNumber(data?.rezult.temp_alfa2), },
    { label: 'Балансовая температура, °С', children: roundNumber(data?.rezult.tbalance_alfa), },
    { label: 'Балансовая температура, °С', children: roundNumber(data?.rezult.tbalance_alfa2), },
  ];

    const charts = [
        { type: 'Теоретическая температура при alfa=1, °С', value: data?.rezult.temp_alfa, },
        { type: 'Теоретическая температура при alfa>1, °С', value: data?.rezult.temp_alfa2, },
        { type: 'Балансовая температура при alfa=1, °С', value: data?.rezult.tbalance_alfa, },
        { type: 'Балансовая температура при alfa>1, °С', value: data?.rezult.tbalance_alfa2, },
    ];

    const config = {
      appendPadding: 40,
      data: charts,
      angleField: 'value',
      colorField: 'type',
      radius: 0.8,
      label: {
          type: 'outer',
          content: '{name} {percentage}',
      },
      interactions: [
          {
              type: 'pie-legend-active',
          },
          {
              type: 'element-active',
          },
      ],
  };

    return (
        <>
		      <ReactToPrint
        trigger={() => (
          <Button type="primary">
            Печать
          </Button>
        )}
        content={() => componentRef.current}
      />
      <div ref={componentRef}>
        <PrintComponent
          data={data}
          items={items}
          items2={items2}
          items3={items3}
          charts={charts}
          config={config}
        />
      </div>

		</>

  );
};
export default DocsPage;

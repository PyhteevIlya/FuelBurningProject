import { useParams } from "@/.umi/exports";
import request from "@/utils/request";
import { Pie } from "@ant-design/plots";
import { Space, DescriptionsProps, Descriptions, Button } from "antd";
import React, { useRef, useState } from "react";
import ReactToPrint from "react-to-print";


const PrintComponent = ({ data, items, items2, charts, config }) => (
  <>
            <Space direction="vertical" style={{ marginBottom: '10px' }}>

            </Space>

            <div>
                <h2 style={{ textAlign: 'center' }}>Исходные данные</h2>
                <Descriptions
                    bordered
                    layout="vertical"
                    size="middle"
                    items={items2} />
            </div>

			  <div>
				<h2 style={{ textAlign: 'center' }}>Итоговые расчетные показатели</h2>
				<Descriptions
				  bordered
				  layout="vertical"
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
        request(`https://localhost:7050/LiquidController2/Report?id=${params.id}`).then(result => {
            console.log(result);
            setData(result)
        });
    }, []);

    const roundNumber = (value) => {
        // Округлить значение до двух знаков после запятой
        return Number(value).toFixed(3);
    };

    const items2: DescriptionsProps['items'] = [
        { label: 'Название варианта исходных данных', children: data?.dataInput.name, },
        { label: 'Тип расчета', children: data?.dataInput.typeCalculation, },
        { label: 'Описание', children: data?.dataInput.description, },
        { label: 'Масса C,%', children: roundNumber(data?.dataInput.liquidFuelModel.c), },
        { label: 'Масса H,%', children: roundNumber(data?.dataInput.liquidFuelModel.h), },
        { label: 'Масса S,%', children: roundNumber(data?.dataInput.liquidFuelModel.s), },
        { label: 'Масса N,%', children: roundNumber(data?.dataInput.liquidFuelModel.n), },
        { label: 'Масса O,%', children: roundNumber(data?.dataInput.liquidFuelModel.o), },
        { label: 'Содержание влаги в топливе, масс. Wp,%', children: roundNumber(data?.dataInput.liquidFuelModel.wp), },
        { label: 'Содержание золы в топливе, масс. Ap,%', children: roundNumber(data?.dataInput.liquidFuelModel.ap), },
        { label: 'Температура подогрева воздуха перед горением, °С', children: roundNumber(data?.dataInput.liquidFuelModel.t_v), },
        { label: 'Температура подогрева топлива перед горением, С', children: roundNumber(data?.dataInput.liquidFuelModel.t_t), },
        { label: 'Коэф.расхода воздуха на горение', children: roundNumber(data?.dataInput.liquidFuelModel.alfaG), },
        { label: 'Механический недожог топлива, % к теплоте сгорания топлива', children: roundNumber(data?.dataInput.liquidFuelModel.m_недожог), },
        { label: 'Влагосодержание воздуха, г/м3 сухого воздуха', children: roundNumber(data?.dataInput.liquidFuelModel.gg), },
    ]

    const items: DescriptionsProps['items'] = [
      { label: 'Теоретический расход окислителя на горение V_O2, м3/м3', children: roundNumber(data?.rezult.v_O2), },
      { label: 'Действительный расход окислителя на горение Lo_св, м3/м3', children: roundNumber(data?.rezult.lo_св), },
      { label: 'Теоретический расход окислителя на горение Lo_вв, м3/м3', children: roundNumber(data?.rezult.lo_вв), },
      { label: 'Действительный расход окислителя на горение L_alfa_вв, м3/м3', children: roundNumber(data?.rezult.l_alfa_вв), },
      { label: 'Количество CO2 в продуктах горения, м3/м3 Vo_CO2', children: roundNumber(data?.rezult.vo_CO2_alfa1_g), },
      { label: 'Количество CO2 в продуктах горения, м3/м3 Vo_CO2 при alfa2', children: roundNumber(data?.rezult.vo_CO2_alfa2_g), },
      { label: 'Количество SO2 в продуктах горения, м3/м3 Vo_SO2', children: roundNumber(data?.rezult.vo_SO2_alfa1_g), },
      { label: 'Количество SO2 в продуктах горения, м3/м3 Vo_SO2 при alfa2', children: roundNumber(data?.rezult.vo_SO2_alfa2_g), },
  
      { label: 'Количество Vo в продуктах горения, м3/м3', children: roundNumber(data?.rezult.vo), },
  
      { label: 'Количество H2O в продуктах горения, м3/м3', children: roundNumber(data?.rezult.vo_H2O_alfa1_g), },
      { label: 'Количество H2O в продуктах горения, м3/м3 при alfa2', children: roundNumber(data?.rezult.vo_H2O_alfa2_g), },
      { label: 'Количество N2 в продуктах горения, м3/м3', children: roundNumber(data?.rezult.vo_N2_alfa1_g), },
      { label: 'Количество N2 в продуктах горения, м3/м3 при alfa2', children: roundNumber(data?.rezult.vo_N2_alfa2_g), },
      { label: 'Количество CO в продуктах горения, м3/м3', children: roundNumber(data?.rezult.vo_CO_alfa1_g), },
      { label: 'Количество CO в продуктах горения, м3/м3 при alfa2', children: roundNumber(data?.rezult.vo_CO_alfa2_g), },
      { label: 'Количество H2 в продуктах горения, м3/м3', children: roundNumber(data?.rezult.vo_H2_alfa1_g), },
      { label: 'Количество H2 в продуктах горения, м3/м3 при alfa2', children: roundNumber(data?.rezult.vo_H2_alfa2_g), },
      { label: 'Количество O2 в продуктах горения, м3/м3', children: roundNumber(data?.rezult.vo_O2_alfa1_g), },
      { label: 'Количество O2 в продуктах горения, м3/м3 при alfa2', children: roundNumber(data?.rezult.vo_O2_alfa2_g), },
      { label: 'Количество избыточного кислорода в продуктах горения, м3/м3', children: roundNumber(data?.rezult.v_O2_izd_alfa2_g), },
      { label: 'Действительное количество продуктов горения, м3/кг топлива', children: roundNumber(data?.rezult.v_alfa_g), },
      { label: 'Содежание CO2 в продуктах горения, %', children: roundNumber(data?.rezult.cO2_alfa1_g), },
      { label: 'Содежание CO2 в продуктах горения, % при alfa2', children: roundNumber(data?.rezult.cO2_alfa2_g), },
      { label: 'Содержание SO2 в продуктах горения, %', children: roundNumber(data?.rezult.sO2_alfa1_g), },
      { label: 'Содержание SO2 в продуктах горения, % при alfa2', children: roundNumber(data?.rezult.sO2_alfa2_g), },
      { label: 'Содежание H2O в продуктах горения, %', children: roundNumber(data?.rezult.h2O_alfa1_g), },
      { label: 'Содежание H2O в продуктах горения, % при alfa2', children: roundNumber(data?.rezult.h2O_alfa2_g), },
      { label: 'Содержание N2 в продуктах горения, %', children: roundNumber(data?.rezult.n2_alfa1_g), },
      { label: 'Теплота сгорания топлива, кДж/(м3)', children: roundNumber(data?.rezult.q_нр_g), },
  
      { label: 'Содержание N2 в продуктах горения, % при alfa2', children: roundNumber(data?.rezult.n2_alfa2_g), },
  
      { label: 'Содежание CO в продуктах горения (диссоциация), %', children: roundNumber(data?.rezult.cO_alfa1_g), },
      { label: 'Содежание CO в продуктах горения (диссоциация), % при alfa2', children: roundNumber(data?.rezult.cO_alfa2_g), },
      { label: 'Содержание H2 в продуктах горения (диссоциация), %', children: roundNumber(data?.rezult.h2_alfa1_g), },
      { label: 'Содержание H2 в продуктах горения (диссоциация), % при alfa2', children: roundNumber(data?.rezult.h2_alfa2_g), },
      { label: 'Содежание O2 в продуктах горения, %', children: roundNumber(data?.rezult.o2_alfa1_g), },
      { label: 'Содежание O2 в продуктах горения, % при alfa2', children: roundNumber(data?.rezult.o2_alfa2_g), },
      { label: 'Общая процентная сумма всех компонентов (должна быть 100 %), %', children: roundNumber(data?.rezult.sum_alfa1_g), },
      { label: 'Общая процентная сумма всех компонентов (должна быть 100 %), % при alfa2', children: roundNumber(data?.rezult.sum_alfa2_g), },
  
      { label: 'Удельная теплоемкость газообразного топлива, кДж/(м3 * С)', children: roundNumber(data?.rezult.c_топл_g), },
      { label: 'Удельная теплоемкость воздуха, кДж/(м3 * С)', children: roundNumber(data?.rezult.c_возд_g), },
      { label: 'Воздух в ПГ, %', children: roundNumber(data?.rezult.pG_возд_g), },
      { label: 'Химическая энтальпия топлива, кДж/м^3', children: roundNumber(data?.rezult.iхим_alfa1_g), },
      { label: 'Химическая энтальпия топлива, кДж/м^3 при alfa2', children: roundNumber(data?.rezult.iхим_alfa2_g), },
      { label: 'Физическая энтальпия подогрева топлива, кДж/м^3', children: roundNumber(data?.rezult.iтопл_alfa1_g), },
      { label: 'Физическая энтальпия подогрева топлива, кДж/м^3 при alfa2', children: roundNumber(data?.rezult.iтопл_alfa2_g), },
      { label: 'Физическая энтальпия подогрева воздуха, кДж/м^3', children: roundNumber(data?.rezult.iвозд_alfa1_g), },
      { label: 'Физическая энтальпия подогрева воздуха, кДж/м^3 при alfa2', children: roundNumber(data?.rezult.iвозд_alfa2_g), },
      { label: 'Общая (теоретическая) энтальпия продуктов горения, кДж/м^3', children: roundNumber(data?.rezult.iобщ_т_alfa1_g), },
      { label: 'Общая (теоретическая) энтальпия продуктов горения, кДж/м^3 при alfa2', children: roundNumber(data?.rezult.iобщ_т_alfa2_g), },
      { label: 'Энтальпия химического недожога, кДж/м^3', children: roundNumber(data?.rezult.i_3_i_4_alfa1_g), },
      { label: 'Энтальпия химического недожога, кДж/м^3 при alfa2', children: roundNumber(data?.rezult.i_3_i_4_alfa2_g), },
      { label: 'Общая балансовая энтальпия продуктов горения, кДж/м^3 i_общ_б', children: roundNumber(data?.rezult.i_общ_б_alfa_g), },
      { label: 'Общая балансовая энтальпия продуктов горения, кДж/м^3 i_общ_б при alfa2', children: roundNumber(data?.rezult.i_общ_б_alfa2_g), },
      { label: 'Теоретическая температура, °С', children: roundNumber(data?.rezult.temp_alfa_g), },
      { label: 'Теоретическая температура, °С при alfa2', children: roundNumber(data?.rezult.temp_alfa2_g), },
      { label: 'Балансовая температура, °С', children: roundNumber(data?.rezult.tbalance_alfa_g), },
      { label: 'Балансовая температура, °С при alfa2', children: roundNumber(data?.rezult.tbalance_alfa2_g), },
    ];
  
    const charts = [
        { type: 'Теоретическая температура при alfa=1, °С', value: data?.rezult.temp_alfa_g, },
        { type: 'Теоретическая температура при alfa>1, °С', value: data?.rezult.temp_alfa2_g, },
        { type: 'Балансовая температура при alfa=1, °С', value: data?.rezult.tbalance_alfa_g, },
        { type: 'Балансовая температура при alfa>1, °С', value: data?.rezult.tbalance_alfa2_g, },
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
          charts={charts}
          config={config}
        />
      </div>

		</>

  );
};
export default DocsPage;
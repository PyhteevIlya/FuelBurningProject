import request from "@/utils/request";
import { Link, useParams } from "@umijs/max";
import { Space, DescriptionsProps, Descriptions, Button, Form } from "antd";
import React, { useState } from "react";

const DocsPage = (props: any) => {
  const params = useParams();
  const [data, setData] = React.useState<any>();
  const [descriptionsVisible, setDescriptionsVisible] = useState(false);

  React.useEffect(() => {
    request(`https://localhost:7050/LiquidController2/Calc?id=${params.id}`).then(result => {
      console.log(result);
      setData(result)
    });
  }, []);

  const roundNumber = (value) => {
    // Округлить значение до двух знаков после запятой
    return Number(value).toFixed(3);
  };

  //Итоговые расчетные показатели
  const items: DescriptionsProps['items'] = [
    { label: 'Теоретический расход окислителя на горение V_O2, м3/м3', children: roundNumber(data?.v_O2), },
    { label: 'Действительный расход окислителя на горение Lo_св, м3/м3', children: roundNumber(data?.lo_св), },
    { label: 'Теоретический расход окислителя на горение Lo_вв, м3/м3', children: roundNumber(data?.lo_вв), },
    { label: 'Действительный расход окислителя на горение L_alfa_вв, м3/м3', children: roundNumber(data?.l_alfa_вв), },
    { label: 'Количество CO2 в продуктах горения, м3/м3 Vo_CO2', children: roundNumber(data?.vo_CO2_alfa1_g), },
    { label: 'Количество CO2 в продуктах горения, м3/м3 Vo_CO2 при alfa2', children: roundNumber(data?.vo_CO2_alfa2_g), },
    { label: 'Количество SO2 в продуктах горения, м3/м3 Vo_SO2', children: roundNumber(data?.vo_SO2_alfa1_g), },
    { label: 'Количество SO2 в продуктах горения, м3/м3 Vo_SO2 при alfa2', children: roundNumber(data?.vo_SO2_alfa2_g), },

    { label: 'Количество Vo в продуктах горения, м3/м3', children: roundNumber(data?.vo), },

    { label: 'Количество H2O в продуктах горения, м3/м3', children: roundNumber(data?.vo_H2O_alfa1_g), },
    { label: 'Количество H2O в продуктах горения, м3/м3 при alfa2', children: roundNumber(data?.vo_H2O_alfa2_g), },
    { label: 'Количество N2 в продуктах горения, м3/м3', children: roundNumber(data?.vo_N2_alfa1_g), },
    { label: 'Количество N2 в продуктах горения, м3/м3 при alfa2', children: roundNumber(data?.vo_N2_alfa2_g), },
    { label: 'Количество CO в продуктах горения, м3/м3', children: roundNumber(data?.vo_CO_alfa1_g), },
    { label: 'Количество CO в продуктах горения, м3/м3 при alfa2', children: roundNumber(data?.vo_CO_alfa2_g), },
    { label: 'Количество H2 в продуктах горения, м3/м3', children: roundNumber(data?.vo_H2_alfa1_g), },
    { label: 'Количество H2 в продуктах горения, м3/м3 при alfa2', children: roundNumber(data?.vo_H2_alfa2_g), },
    { label: 'Количество O2 в продуктах горения, м3/м3', children: roundNumber(data?.vo_O2_alfa1_g), },
    { label: 'Количество O2 в продуктах горения, м3/м3 при alfa2', children: roundNumber(data?.vo_O2_alfa2_g), },
    { label: 'Количество избыточного кислорода в продуктах горения, м3/м3', children: roundNumber(data?.v_O2_izd_alfa2_g), },
    { label: 'Действительное количество продуктов горения, м3/кг топлива', children: roundNumber(data?.v_alfa_g), },
    { label: 'Содежание CO2 в продуктах горения, %', children: roundNumber(data?.cO2_alfa1_g), },
    { label: 'Содежание CO2 в продуктах горения, % при alfa2', children: roundNumber(data?.cO2_alfa2_g), },
    { label: 'Содержание SO2 в продуктах горения, %', children: roundNumber(data?.sO2_alfa1_g), },
    { label: 'Содержание SO2 в продуктах горения, % при alfa2', children: roundNumber(data?.sO2_alfa2_g), },
    { label: 'Содежание H2O в продуктах горения, %', children: roundNumber(data?.h2O_alfa1_g), },
    { label: 'Содежание H2O в продуктах горения, % при alfa2', children: roundNumber(data?.h2O_alfa2_g), },
    { label: 'Содержание N2 в продуктах горения, %', children: roundNumber(data?.n2_alfa1_g), },
    { label: 'Теплота сгорания топлива, кДж/(м3)', children: roundNumber(data?.q_нр_g), },

    { label: 'Содержание N2 в продуктах горения, % при alfa2', children: roundNumber(data?.n2_alfa2_g), },

    { label: 'Содежание CO в продуктах горения (диссоциация), %', children: roundNumber(data?.cO_alfa1_g), },
    { label: 'Содежание CO в продуктах горения (диссоциация), % при alfa2', children: roundNumber(data?.cO_alfa2_g), },
    { label: 'Содержание H2 в продуктах горения (диссоциация), %', children: roundNumber(data?.h2_alfa1_g), },
    { label: 'Содержание H2 в продуктах горения (диссоциация), % при alfa2', children: roundNumber(data?.h2_alfa2_g), },
    { label: 'Содежание O2 в продуктах горения, %', children: roundNumber(data?.o2_alfa1_g), },
    { label: 'Содежание O2 в продуктах горения, % при alfa2', children: roundNumber(data?.o2_alfa2_g), },
    { label: 'Общая процентная сумма всех компонентов (должна быть 100 %), %', children: roundNumber(data?.sum_alfa1_g), },
    { label: 'Общая процентная сумма всех компонентов (должна быть 100 %), % при alfa2', children: roundNumber(data?.sum_alfa2_g), },

    { label: 'Удельная теплоемкость газообразного топлива, кДж/(м3 * С)', children: roundNumber(data?.c_топл_g), },
    { label: 'Удельная теплоемкость воздуха, кДж/(м3 * С)', children: roundNumber(data?.c_возд_g), },
    { label: 'Воздух в ПГ, %', children: roundNumber(data?.pG_возд_g), },
    { label: 'Химическая энтальпия топлива, кДж/м^3', children: roundNumber(data?.iхим_alfa1_g), },
    { label: 'Химическая энтальпия топлива, кДж/м^3 при alfa2', children: roundNumber(data?.iхим_alfa2_g), },
    { label: 'Физическая энтальпия подогрева топлива, кДж/м^3', children: roundNumber(data?.iтопл_alfa1_g), },
    { label: 'Физическая энтальпия подогрева топлива, кДж/м^3 при alfa2', children: roundNumber(data?.iтопл_alfa2_g), },
    { label: 'Физическая энтальпия подогрева воздуха, кДж/м^3', children: roundNumber(data?.iвозд_alfa1_g), },
    { label: 'Физическая энтальпия подогрева воздуха, кДж/м^3 при alfa2', children: roundNumber(data?.iвозд_alfa2_g), },
    { label: 'Общая (теоретическая) энтальпия продуктов горения, кДж/м^3', children: roundNumber(data?.iобщ_т_alfa1_g), },
    { label: 'Общая (теоретическая) энтальпия продуктов горения, кДж/м^3 при alfa2', children: roundNumber(data?.iобщ_т_alfa2_g), },
    { label: 'Энтальпия химического недожога, кДж/м^3', children: roundNumber(data?.i_3_i_4_alfa1_g), },
    { label: 'Энтальпия химического недожога, кДж/м^3 при alfa2', children: roundNumber(data?.i_3_i_4_alfa2_g), },
    { label: 'Общая балансовая энтальпия продуктов горения, кДж/м^3 i_общ_б', children: roundNumber(data?.i_общ_б_alfa_g), },
    { label: 'Общая балансовая энтальпия продуктов горения, кДж/м^3 i_общ_б при alfa2', children: roundNumber(data?.i_общ_б_alfa2_g), },
    { label: 'Теоретическая температура, °С', children: roundNumber(data?.temp_alfa_g), },
    { label: 'Теоретическая температура, °С при alfa2', children: roundNumber(data?.temp_alfa2_g), },
    { label: 'Балансовая температура, °С', children: roundNumber(data?.tbalance_alfa_g), },
    { label: 'Балансовая температура, °С при alfa2', children: roundNumber(data?.tbalance_alfa2_g), },
  ];

  const handleToggleDescriptions = () => {
    setDescriptionsVisible(!descriptionsVisible);
  };

  return (
    <>
      <Space direction="horizontal" style={{ marginBottom: '10px' }}>
        <Link to={`/report_liquid/${params.id}`}>
          <Button type="primary">Печать</Button>
        </Link>
      </Space>
      <div>
        <h2 style={{ textAlign: 'center' }}>Итоговые расчетные показатели</h2>
        <Descriptions
          bordered
          layout="vertical"
          size="middle"
          items={items} />
      </div>

    </>
  );

}
export default DocsPage;
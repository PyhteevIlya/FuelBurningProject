import request from "@/utils/request";
import { Link, useParams } from "@umijs/max";
import { Space, DescriptionsProps, Descriptions, Button, Form } from "antd";
import React, { useState } from "react";

const DocsPage = (props: any) => {
  const params = useParams();
  const [data, setData] = React.useState<any>();
  const [descriptionsVisible, setDescriptionsVisible] = useState(false);

  React.useEffect(() => {
    request(`https://localhost:7050/HomeController2/Calc?id=${params.id}`).then(result => {
      console.log(result);
      setData(result)
    });
  }, []);

  const roundNumber = (value) => {
    // Округлить значение до двух знаков после запятой
    return Number(value).toFixed(3);
  };

  //Промежуточные показатели
  const items: DescriptionsProps['items'] = [
    { label: 'Рабочая масса Rh2o,%', children: roundNumber(data?.rh2o), },
    { label: 'Рабочая масса CO2,%', children: roundNumber(data?.rco2), },
    { label: 'Рабочая масса CO,%', children: roundNumber(data?.rco), },
    { label: 'Рабочая масса H2,%', children: roundNumber(data?.rh2), },
    { label: 'Рабочая масса CH4,%', children: roundNumber(data?.rch4), },
    { label: 'Рабочая масса C2H6,%', children: roundNumber(data?.rc2h6), },
    { label: 'Рабочая масса C3H8,%', children: roundNumber(data?.rc3h8), },
    { label: 'Рабочая масса C4H10,%', children: roundNumber(data?.rc4h10), },
    { label: 'Рабочая масса C5H12,%', children: roundNumber(data?.rc5h12), },
    { label: 'Рабочая масса H2S,%', children: roundNumber(data?.rh2s), },
    { label: 'Рабочая масса N2,%', children: roundNumber(data?.rN2), },
    { label: 'Рабочая масса H2O,%', children: roundNumber(data?.sumishdanrab), },
  ];

  //Расчетные показатели
  const items2: DescriptionsProps['items'] = [
    { label: 'Теоретический расход окислителя на горение Lo, м3/м3', children: roundNumber(data?.lo), },
    { label: 'Действительный расход окислителя на горение L_alfa, м3/м3', children: roundNumber(data?.lalfa), },
    { label: 'Количество CO2 в продуктах горения, м3/м3', children: roundNumber(data?.vo_CO2), },
    { label: 'Количество SO2 в продуктах горения, м3/м3', children: roundNumber(data?.vo_SO2), },
    { label: 'Количество H2O в продуктах горения, м3/м3', children: roundNumber(data?.vo_H2O), },
    { label: 'Количество N2 в продуктах горения, м3/м3', children: roundNumber(data?.vo_N2), },
    { label: 'Количество CO в продуктах горения, м3/м3', children: roundNumber(data?.vo_CO), },
    { label: 'Количество H2 в продуктах горения, м3/м3', children: roundNumber(data?.vo_H2), },
    { label: 'Количество O2 в продуктах горения, м3/м3', children: roundNumber(data?.vo_O2), },
    { label: 'Теоретический объем продуктов горения, м3/м3', children: roundNumber(data?.vo), },
    { label: 'Практический выход N2 при избытке окислителя, м3/м3', children: roundNumber(data?.v_alfa_N2), },
    { label: 'Количество избыточного кислорода в продуктах горения, м3/м3', children: roundNumber(data?.v_O2_izb), },
    { label: 'Действительное количество продуктов горения, м3/м3 V_alfa', children: roundNumber(data?.v_alfa), },
    { label: 'Содежание CO2 в продуктах горения, % CO2', children: roundNumber(data?.cO2alfa), },
    { label: 'Содежание CO2 в продуктах горения, % CO2 при alfa2', children: roundNumber(data?.cO2alfa2), },
    { label: 'Содержание SO2 в продуктах горения, % SO2', children: roundNumber(data?.sO2alfa), },
    { label: 'Содержание SO2 в продуктах горения, % SO2 при alfa2', children: roundNumber(data?.sO2alfa2), },
    { label: 'Содежание H2O в продуктах горения, % H2O', children: roundNumber(data?.h2Oalfa), },
    { label: 'Содежание H2O в продуктах горения, % H2O при alfa2', children: roundNumber(data?.h2Oalfa2), },
    { label: 'Содержание N2 в продуктах горения, % N2', children: roundNumber(data?.n2alfa), },
    { label: 'Содержание N2 в продуктах горения, % N2 при alfa2', children: roundNumber(data?.n2alfa2), },
    { label: 'Содежание CO в продуктах горения (диссоциация), % CO', children: roundNumber(data?.cOalfa), },
    { label: 'Содежание CO в продуктах горения (диссоциация), % CO при alfa2', children: roundNumber(data?.cOalfa2), },
    { label: 'Содержание H2 в продуктах горения (диссоциация), % H2', children: roundNumber(data?.h2alfa), },
    { label: 'Содержание H2 в продуктах горения (диссоциация), % H2 при alfa2', children: roundNumber(data?.h2alfa2), },
    { label: 'Содежание O2 в продуктах горения, % O2', children: roundNumber(data?.o2alfa), },
    { label: 'Содежание O2 в продуктах горения, % O2 при alfa2', children: roundNumber(data?.o2alfa2), },
    { label: 'Общая процентная сумма всех компонентов (должна быть 100 %), % Сумма', children: roundNumber(data?.sumalfa), },
    { label: 'Общая процентная сумма всех компонентов (должна быть 100 %), % Сумма  при alfa2', children: roundNumber(data?.sumalfa2), },
    { label: 'Теплота сгорания топлива, кДж/(м3) Q н.р.', children: roundNumber(data?.qнр), },
    { label: 'Удельная теплоемкость газообразного топлива, кДж/(м3 * °С', children: roundNumber(data?.cтопл), },
    { label: 'Удельная теплоемкость воздуха, кДж/(м3 * °С)', children: roundNumber(data?.cвозд), },
    { label: 'Содержание воздуха в продуктах горения, %', children: roundNumber(data?.воздВПГ), },
    { label: 'Химическая энтальпия топлива, кДж/м^3 i_хим', children: roundNumber(data?.i_химalfa), },
    { label: 'Химическая энтальпия топлива, кДж/м^3 i_хим', children: roundNumber(data?.i_химalfa2), },
    { label: 'Физическая энтальпия подогрева топлива, кДж/м^3 i_топл', children: roundNumber(data?.i_топлalfa), },
    { label: 'Физическая энтальпия подогрева топлива, кДж/м^3 i_топл', children: roundNumber(data?.i_топлalfa2), },
    { label: 'Физическая энтальпия подогрева воздуха, кДж/м^3 i_возд', children: roundNumber(data?.i_воздalfa), },
    { label: 'Физическая энтальпия подогрева воздуха, кДж/м^3 i_возд', children: roundNumber(data?.i_воздalfa2), },
    { label: 'Общая (теоретическая) энтальпия продуктов горения, кДж/м^3', children: roundNumber(data?.i_общ_т_alfa), },
    { label: 'Общая (теоретическая) энтальпия продуктов горения, кДж/м^3', children: roundNumber(data?.i_общ_т_alfa2), },
    { label: 'Энтальпия химического недожога, кДж/м^3', children: roundNumber(data?.i_з_alfa), },
    { label: 'Энтальпия химического недожога, кДж/м^3', children: roundNumber(data?.i_з_alfa2), },
    { label: 'Общая балансовая энтальпия продуктов горения, кДж/м^3 i_общ_б', children: roundNumber(data?.i_общ_б_alfa), },
    { label: 'Общая балансовая энтальпия продуктов горения, кДж/м^3 i_общ_б', children: roundNumber(data?.i_общ_б_alfa2), },
    { label: 'Теоретическая температура, °С', children: roundNumber(data?.temp_alfa), },
    { label: 'Теоретическая температура, °С', children: roundNumber(data?.temp_alfa2), },
    { label: 'Балансовая температура, °С', children: roundNumber(data?.tbalance_alfa), },
    { label: 'Балансовая температура, °С', children: roundNumber(data?.tbalance_alfa2), },
  ];

  const handleToggleDescriptions = () => {
    setDescriptionsVisible(!descriptionsVisible);
  };

  return (
    <>
      <Space direction="horizontal" style={{ marginBottom: '10px' }}>
        <Button type="primary" onClick={handleToggleDescriptions}>
          {descriptionsVisible ? 'Скрыть промежуточные расчетные показатели' : 'Показать промежуточные расчетные показатели'}
        </Button>
        <Link to={`/report_gas/${params.id}`}>
          <Button type="primary">Печать</Button>
        </Link>
      </Space>
      <div>
        <h2 style={{ textAlign: 'center' }}>Итоговые расчетные показатели</h2>
        <Descriptions
          bordered
          layout="vertical"
          size="middle"
          items={items2} />
      </div>

      {descriptionsVisible && (
        <div>
          <h2 style={{ textAlign: 'center' }}>Промежуточные расчетные показатели</h2>
          <Descriptions
            bordered
            layout="vertical"
            labelStyle={{ textAlign: 'center' }}
            size="middle"
            items={items} />
        </div>
      )}


    </>
  );

}
export default DocsPage;
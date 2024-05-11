import request from "@/utils/request";
import { DeleteFilled, EditFilled, PlayCircleFilled } from "@ant-design/icons";
import { Link } from "@umijs/max";
import { Space, Button, Table, message } from "antd";
import { ColumnsType } from "antd/es/table";
import React from "react";

const DocsPage = () => {

  const [dataSource, setDataSource] = React.useState([]);
  const [loading, setLoading] = React.useState(false);

  const getRaschet = (data: any) => {
    setLoading(true);
    request('https://localhost:7293/Home/Raschet').then(result => {
      console.log(result);
      setDataSource(result);
      setLoading(false);
    });
  };

  const removeHandler = (id: number) => {

    request(`https://localhost:7050/HomeController2/Remove?id=${id}`, { method: 'DELETE' }).then(result => {
      console.log(result);
      const newDataSource = dataSource.filter((value, index) => value.id != id);
      console.log(newDataSource);
      setDataSource(newDataSource);
      message.success('Вариант расчета удален')
    });

  }

  React.useEffect(() => {
    getRaschet({});
    document.title = "Расчет показателей барабанной печи";
  }, []);

  const prodsite: ColumnsType<never> = [
    {
      title: 'Название варианта исходных данных',
      dataIndex: 'name',
    },
    {
      title: 'Описание',
      dataIndex: 'description',
    },

    {
      title: 'Действия',
      key: 'action',
      render: (value, record, index) =>
        <>
          <Link to={`/edit_raschet/${record.id}`}>
            <EditFilled />
          </Link>{' / '}
          {index !== 0 && (
            <>
              <a onClick={() => removeHandler(record.id)}>
                <DeleteFilled />
              </a>{' / '}
            </>
          )}
          <Link to={`/rezult/${record.id}`}>
            <PlayCircleFilled />
          </Link>
        </>
        

    }
  ];

return (
  <div>
    <Space direction="vertical" style={{ marginBottom: '10px' }}>
      <Link to="/create/create_raschet">
        <Button type="primary">Новая запись</Button>
      </Link>
    </Space>

    <Space direction="vertical" align="center"></Space>
    <Table
      dataSource={dataSource}
      columns={prodsite}
      loading={loading}
      scroll={{ x: 1300 }} />

  </div>
);

}
export default DocsPage;
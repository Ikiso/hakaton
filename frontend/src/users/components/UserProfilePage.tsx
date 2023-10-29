import { PanelMenu } from 'primereact/panelmenu';
import { MenuItem } from 'primereact/menuitem';
import { Fieldset } from 'primereact/fieldset';
import { Divider } from 'primereact/divider';
import { Image } from 'primereact/image';
import { Button } from 'primereact/button';
import { useNavigate } from 'react-router-dom';

import classes from './UserProfilePage.module.scss';

export const UserProfilePage = () => {
  const navigate = useNavigate();
  const items: MenuItem[] = [
    {
      label: 'Наша кампания',
      icon: 'pi pi-fw pi-sitemap',
      command: () => {
        navigate('/profile/company', { replace: true });
      },
    },
    {
      label: 'Мои действия',
      icon: 'pi pi-fw pi-pencil',
      items: [
        {
          label: 'Мои тесты',
          icon: 'pi pi-fw pi-check-square',
        },
        {
          label: 'Мои результаты',
          icon: 'pi pi-fw pi-eye',
        },
        {
          label: 'Мои обращения',
          icon: 'pi pi-fw pi-info-circle',
        },
        {
          label: 'Мои заявки',
          icon: 'pi pi-fw pi-file-edit',
        },
      ],
    },
    {
      label: 'База',
      icon: 'pi pi-fw pi-database',
      items: [
        {
          label: 'База учебных материалов',
          icon: 'pi pi-fw pi-book',
        },
        {
          label: 'База тестов',
          icon: 'pi pi-fw pi-check-square',
        },
        {
          label: 'База сотрудников',
          icon: 'pi pi-fw pi-users',
        },
      ],
    },
    {
      label: 'Аналитика по компании',
      icon: 'pi pi-fw pi-chart-line',
    },
  ];

  return (
    <div className={classes.profile}>
      <div className={classes.sideBar}>
        <PanelMenu model={items} className="w-full md:w-25rem" />
      </div>
      <div className={classes.content}>
        <div className={classes.content_data}>
          <Fieldset legend="Личные данные пользователя" toggleable>
            <p className="m-0">Дата рождения: 2001-09-11</p>
            <Divider />
            <p className="m-0">Логин: admin</p>
            <Divider />
            <a className="m-0">Сменить пароль</a>
          </Fieldset>
          <Fieldset legend="Данные пользователя" toggleable>
            <p className="m-0">Департамент: как-то департамент</p>
            <Divider />
            <p className="m-0">Отдел: как-то отдел</p>
            <Divider />
            <p className="m-0">Должность: какая-то должность</p>
            <Divider />
            <p className="m-0">Руководитель: какой-то руководитель</p>
            <Divider />
            <p className="m-0">HR-менеджер: какой-то менеджер</p>
            <Divider />
            <p className="m-0">Средний балл по тестированию: средний балл</p>
          </Fieldset>
        </div>
        <div>
          <div className={classes.avatar}>
            <Image
              src="https://static.tildacdn.com/tild6338-3666-4133-a633-643664333838/photo.jpg"
              alt="Image"
              width="250"
              preview
            />
          </div>
          <Button label={'Изменить информацию'} className={classes.changeInfoBtn} />
        </div>
      </div>
    </div>
  );
};

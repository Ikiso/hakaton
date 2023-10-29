import { MegaMenu } from 'primereact/megamenu';
import { SplitButton } from 'primereact/splitbutton';
import { Button } from 'primereact/button';
import { useNavigate } from 'react-router-dom';

export const Header = () => {
  const navigate = useNavigate();

  const btnItems = [
    {
      label: 'Выйти',
      icon: 'pi pi-sign-out',
      command: () => {
        navigate('/auth', { replace: true });
      },
    },
  ];

  const signin = () => {
    navigate('/auth', { replace: true });
  };

  const profile = () => {
    navigate('/profile', { replace: true });
  };

  const start = (
    <img
      alt="logo"
      src="https://www.parcdumorvan.org/wp-content/uploads/2019/02/logo2.png"
      height="40"
      className="mr-2"
    ></img>
  );

  let end = <SplitButton label="Личный кабинет" icon="pi pi-user" model={btnItems} onClick={profile} />;

  if (!localStorage.getItem('tk')) {
    // если есть токен, кнопка входа в header
    end = <Button label="Войти" icon="pi pi-sign-in" onClick={signin} />;
  }

  const activeClass = { backgroundColor: '#E9ECEF', borderRadius: '10px', boxShadow: 'inset 0 0 0 0.15rem #C7D2FE' };

  const items = [
    {
      label: 'Возможности',
      style: {},
      command: () => {
        navigate('/opportunities', { replace: true });
        for (const item of items) {
          item.style = {};
        }
        this.style = activeClass;
      },
    },
    {
      label: 'Тарифы',
      style: {},
      command: () => {
        navigate('/rate', { replace: true });
        for (const item of items) {
          item.style = {};
        }
        this.style = activeClass;
      },
    },
    {
      label: 'Внедрение',
      style: {},
      command: () => {
        navigate('/integration', { replace: true });
        for (const item of items) {
          item.style = {};
        }
        this.style = activeClass;
      },
    },
    {
      label: 'Отзывы',
      style: {},
      command: () => {
        navigate('/feedback', { replace: true });
        for (const item of items) {
          item.style = {};
        }
        this.style = activeClass;
      },
    },
    {
      label: 'Поддержка',
      style: {},
      command: () => {
        // navigate('/feedback', { replace: true });
      },
    },
    {
      label: 'Зарегистрировать новую школу',
      style: {},
      command: () => {
        // navigate('/feedback', { replace: true });
      },
    },
  ];

  return (
    <div>
      <MegaMenu model={items} start={start} end={end} breakpoint="960px" style={{ position: 'sticky' }} />
    </div>
  );
};

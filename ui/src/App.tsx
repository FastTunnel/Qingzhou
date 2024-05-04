import './App.css'
import AppLayout, { ELayout } from './layout/app-layout';
export function App() {
  const AppContainer = AppLayout[ELayout.side];

  return <>
    <AppContainer></AppContainer>
  </>
}


// import { memo, useState } from 'react';

// export function App() {
//   const [name, setName] = useState('');
//   const [address, setAddress] = useState('');
//   console.log("App rendered at", new Date().toLocaleTimeString());
//   return (
//     <>
//       <label>
//         Name{': '}
//         <input value={name} onChange={e => setName(e.target.value)} />
//       </label>
//       <label>
//         Address{': '}
//         <input value={address} onChange={e => setAddress(e.target.value)} />
//       </label>
//       <Greeting name={name} />
//     </>
//   );
// }

// const Greeting = memo(function Greeting(props: { name: string }) {
//   console.log("Greeting was rendered at", new Date().toLocaleTimeString());
//   return <h3>Hello{props.name && ', '}{props.name}!</h3>;
// });

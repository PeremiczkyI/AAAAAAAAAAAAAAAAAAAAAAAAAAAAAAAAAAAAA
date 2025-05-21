import React, { useState } from 'react';
import axios from 'axios';

function NewPlayer() {
  const [name, setName] = useState('');
  const [birthDate, setBirthDate] = useState('');
  const [worldChWon, setWorldChWon] = useState('');
  const [imageUrl, setImageUrl] = useState('');
  const [profileUrl, setProfileUrl] = useState('');

  const createPlayer = async (event) => {
    event.preventDefault();

    try {
      const response = await axios.post('https://darts.sulla.hu/darts', {
        name,
        birth_date: birthDate,
        world_ch_won: worldChWon,
        image_url: imageUrl,
        profile_url: profileUrl
      });

      alert('Darts játékos sikeresen hozzáadva:');
    } catch (error) {
      console.error('Error creating player:', error);
    }
  };

  return (
    <div className='container mt-5'>
      <form onSubmit={createPlayer}>
        <div className='row'>
          <h5>Név</h5>
          <input
            type='text'
            id='name'
            value={name}
            onChange={(e) => setName(e.target.value)}
          />
        </div>
        <div className='row'>
          <h5>Születési dátum</h5>
          <input
            type='text'
            id='birth_date'
            value={birthDate}
            onChange={(e) => setBirthDate(e.target.value)}
          />
        </div>
        <div className='row'>
          <h5>Megnyert világbajnokságok</h5>
          <input
            type='text'
            id='world_ch_won'
            value={worldChWon}
            onChange={(e) => setWorldChWon(e.target.value)}
          />
        </div>
        <div className='row'>
          <h5>Kép</h5>
          <input
            type='text'
            id='image_url'
            value={imageUrl}
            onChange={(e) => setImageUrl(e.target.value)}
          />
        </div>
        <div className='row'>
          <h5>Wikipédia link</h5>
          <input
            type='text'
            id='profile_url'
            value={profileUrl}
            onChange={(e) => setProfileUrl(e.target.value)}
          />
        </div>
        <hr />
        <div className='row'>
          <button type='submit'>Létrehozás</button>
        </div>
      </form>
    </div>
  );
}

export default NewPlayer;
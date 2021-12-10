import React, {Component} from 'react';
import {
  StyleSheet,
  Text,
  View,
  Image,
  TouchableOpacity,
} from 'react-native';

import AsyncStorage from '@react-native-async-storage/async-storage';
import jwtDecode from 'jwt-decode';

export default class Perfil extends Component {
  constructor(props) {
    super(props);
    this.state = {
      nome: '',
      email: '',
    };
  }
  buscarDadosStorage = async () => {
    try {
      const valorToken = await AsyncStorage.getItem('userToken');


      if (valorToken != null) {
        this.setState({nome: jwtDecode(valorToken).name});
        this.setState({email: jwtDecode(valorToken).email});
      }
    } catch (error) {
      console.warn(error);
    }
  };

  componentDidMount() {
    this.buscarDadosStorage();
  }

  realizarLogout = async () => {
    //vamos remover o armazenamento local.
    try {
      await AsyncStorage.removeItem('userToken');
      this.props.navigation.navigate('Login'); //tem que ser mesmo nome.
    } catch (error) {
      console.warn(error);
    }
  };

  render() {
    return (
      <View style={styles.main}>
        {/* Cabeçalho - Header */}
        <View style={styles.mainHeader}>
          <View style={styles.buttonContainer}>
          </View>
          <View style={styles.mainHeaderRow}>
            
            <Text style={styles.mainHeaderText}>{'Perfil'.toUpperCase()}</Text>
          </View>
          <View style={styles.mainHeaderLine} />
        </View>

        {/* Corpo - Body - Section */}
        <View style={styles.mainBody}>
          <View style={styles.mainBodyInfo}>
            
              <Image
                source={require('../../assets/img/profile2x.png')}
              />
        

            <Text style={styles.mainBodyText}>{this.state.nome}</Text>
            <Text style={styles.mainBodyText}>{this.state.email}</Text>
          </View>

          <TouchableOpacity
            style={styles.btnLogout}
            onPress={this.realizarLogout}>
            <Text style={styles.btnLogoutText}>SAIR</Text>
          </TouchableOpacity>
        </View>
      </View>
    );
  }
}

const styles = StyleSheet.create({
  // conteúdo da main
  main: {
    flex: 1,
    backgroundColor: '#e5e5e5',
  },
  // cabeçalho
  mainHeader: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
  },
  mainHeaderRow: {
    flexDirection: 'row',
    marginTop: 70
  },
  // imagem do cabeçalho
  mainHeaderImg: {
    width: 22,
    height: 22,
    marginRight: -5,
    marginTop: -12,
  },
  // texto do cabeçalho
  mainHeaderText: {
    fontSize: 25,
    letterSpacing: 5,
    color: 'black',
    fontFamily: 'Open Sans',
  },
  // linha de separação do cabeçalho
  mainHeaderLine: {
    width: 220,
    paddingTop: 10,
    borderBottomColor: 'black',
    borderBottomWidth: 1,
  },

  // conteúdo do body
  mainBody: {
    flex: 4,
    alignItems: 'center',
    justifyContent: 'space-between',
  },
  // informações do usuário
  mainBodyInfo: {
    alignItems: 'center',
    marginTop:70
    
  },
  mainBodyImg: {
    backgroundColor: 'black',
    width: 100,
    height: 100,
    borderRadius: 50,
    marginBottom: 50,
  },
  mainBodyText: {
    marginTop: 40,
    color: 'black',
    fontSize: 15,
    marginBottom: 20,
  },
  // botão de logout
  btnLogout: {
    alignItems: 'center',
    justifyContent: 'center',
    height: 80,
    width: 240,
    borderTopWidth: 1,
    borderColor: 'black',
    marginBottom: 50,
  },
  // texto do botão
  btnLogoutText: {
    fontSize: 20,
    color: '#CB77FF',
  },
});

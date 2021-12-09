import React, { Component } from 'react';
import {
    FlatList,
    SafeAreaView,
    ScrollView,
    StatusBar,
    StyleSheet,
    Text,
    useColorScheme,
    TouchableOpacity,
    View,
    ImageBackground,
    Image,
    TextInput,
} from 'react-native';

import {
    Colors,
    DebugInstructions,
    Header,
    LearnMoreLinks,
    ReloadInstructions,
} from 'react-native/Libraries/NewAppScreen';



//navigation
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
const bottomTab = createBottomTabNavigator();
import { NavigationContainer } from '@react-navigation/native';


import api from '../services/api';
import AsyncStorage from '@react-native-async-storage/async-storage';



export default class Login extends Component {

    constructor(props) {
        super(props)
        this.state = {
            email: 'alexandre@gmail.com',
            senha: 'alezinhogameplays'
        };
    }



    realizarLogin = async () => {


        console.warn(this.state.email + ' ' + this.state.senha)

        try {
            const resposta = await api.post('/Login', {

                email: this.state.email,
                senha: this.state.senha
            });

            const token = resposta.data.token
            console.warn(token)


            await AsyncStorage.setItem('userToken', token)
            console.warn(resposta);

            if (resposta.status === 200) {
                this.props.navigation.navigate('Main')
            }

        else{
            console.warn('Usuario/Email inválido')
        }

        } catch (error) {
            console.warn(error)
        }






    };


    render() {
        return (

            <ImageBackground
                source={(require('../../assets/img/Background.png'))}
                style={StyleSheet.absoluteFillObject}>







                <View style={styles.ContainerLogin}>

                    <Image
                        source={(require('../../assets/img/Group1.png'))}
                        style={styles.MainImgLogin}
                    />


                    <TextInput style={styles.inputLogin}
                        placeholder='Username'
                        placeholderTextColor='#000000'
                        keyboardType='email-address'
                        onChangeText={email => this.setState(
                            { email })}
                    />

                    <TextInput style={styles.inputLogin}
                        placeholder='Password'
                        placeholderTextColor='#000000'
                        keyboardType='default'
                        onChangeText={senha => this.setState(
                            { senha })}
                        secureTextEntry={true}
                    />

                    <TouchableOpacity
                        style={styles.btnLogin}
                        onPress={this.realizarLogin}
                    >

                        <Text style={styles.LoginText}>Login</Text>

                    </TouchableOpacity>
                </View>


            </ImageBackground>











        )
    }



}

const styles = StyleSheet.create({

    Main: {
        //flex: 1,
        //backgroundColor: '#F4F8FF',
        justifyContent: 'center',
        alignItems: 'center',
        width: '100%',
        height: '100%',
    },

    btnLogin: {
        alignItems: 'center',
        justifyContent: 'center',
        height: 51,
        width: 250,
        backgroundColor: '#FFFFFF',
        borderColor: '#FFFFFF',
        borderWidth: 1,
        borderRadius: 7,
        shadowOffset: { height: 5, width: 10 },
    },
    ContainerLogin: {
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center',
    },
    LoginText: {
        fontSize: 18,
        color: '#467CE5',
        fontFamily: 'Open Sans Light',
        letterSpacing: 2,
        textTransform: 'uppercase'
    },

    MainImgLogin: {
        margin: 60,
        marginTop: 0
    },

    inputLogin: {
        width: 250,
        marginBottom: 18,
        fontSize: 16,
        borderBottomColor: '#fff',
        borderBottomWidth: 1

    }

});
